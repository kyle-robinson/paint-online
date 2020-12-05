﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace PaintApp
{
    public class Client
    {
        private TcpClient tcpClient;
        private UdpClient udpClient;
        private BinaryReader reader;
        private BinaryWriter writer;
        private PaintForm paintForm;
        private NetworkStream stream;
        private BinaryFormatter formatter;

        public Client()
        {
            tcpClient = new TcpClient();
            udpClient = new UdpClient();
        }

        public bool Connect( string ipAddress, int port )
        {
            try
            {
                tcpClient.Connect( ipAddress, port );
                udpClient.Connect( ipAddress, port );
                stream = tcpClient.GetStream();
                reader = new BinaryReader( stream, Encoding.UTF8 );
                writer = new BinaryWriter( stream, Encoding.UTF8 );
                formatter = new BinaryFormatter();
                return true;
            }
            catch( Exception exception )
            {
                Console.WriteLine( "Client Exception: " + exception.Message );
                return false;
            }
        }

        public void Run()
        {
            try
            {
                paintForm = new PaintForm( this );

                Thread tcpThread = new Thread( () => { TcpProcessServerResponse(); } );
                tcpThread.Start();

                Thread udpThread = new Thread( () => { UdpProcessServerResponse(); } );
                udpThread.Start();

                Login();

                paintForm.ShowDialog();
            }
            catch( Exception exception )
            {
                Console.WriteLine( exception.Message );
            }
            finally
            {
                tcpClient.Close();
                udpClient.Close();
            }
        }

        public void Login()
        {
            TcpSendMessage( new LoginPacket( (IPEndPoint)udpClient.Client.LocalEndPoint ) );
        }

        private void TcpProcessServerResponse()
        {
            try
            {
                int numberOfBytes = 0;
                while ( ( numberOfBytes = reader.ReadInt32() ) != -1 )
                {
                    byte[] buffer = reader.ReadBytes( numberOfBytes );
                    MemoryStream memoryStream = new MemoryStream( buffer );
                    Packet packet = formatter.Deserialize( memoryStream ) as Packet;
                    switch ( packet.packetType )
                    {
                        case PacketType.EMPTY:
                            Console.WriteLine( "Empty packet" );
                            break;
                        case PacketType.PAINTING:
                            PaintPacket paintPacket = (PaintPacket)packet;
                            paintForm.UpdateCanvas( paintPacket.xPos, paintPacket.yPos, paintPacket.mouseLocation );
                            break;
                        case PacketType.PEN:
                            PenPacket penPacket = (PenPacket)packet;
                            paintForm.UpdatePen( penPacket.penColor );
                            break;
                    }
                }
            }
            catch( Exception exception )
            {
                Console.WriteLine( exception.Message );
            }
        }

        private void UdpProcessServerResponse()
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint( IPAddress.Any, 0 );
                while ( true )
                {
                    byte[] bytes = udpClient.Receive( ref endPoint );
                    MemoryStream memoryStream = new MemoryStream( bytes );
                    Packet packet = formatter.Deserialize( memoryStream ) as Packet;
                    switch( packet.packetType )
                    {
                        case PacketType.EMPTY:
                            Console.WriteLine( "Empty packet" );
                            break;
                        case PacketType.PAINTING:
                            PaintPacket paintPacket = (PaintPacket)packet;
                            paintForm.UpdateCanvas( paintPacket.xPos, paintPacket.yPos, paintPacket.mouseLocation );
                            break;
                        case PacketType.PEN:
                            PenPacket penPacket = (PenPacket)packet;
                            paintForm.UpdatePen( penPacket.penColor );
                            break;
                    }
                }
            }
            catch( SocketException e )
            {
                Console.WriteLine( e.Message );
            }
        }

        public void TcpSendMessage( Packet message )
        {
            MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize( memoryStream, message );
            byte[] buffer = memoryStream.GetBuffer();
            writer.Write( buffer.Length );
            writer.Write( buffer );
            writer.Flush();
            memoryStream.Close();
        }

        public void UdpSendMessage( Packet message )
        {
            MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize( memoryStream, message );
            byte[] buffer = memoryStream.GetBuffer();
            udpClient.Send( buffer, buffer.Length );
            memoryStream.Close();
        }
    }
}
