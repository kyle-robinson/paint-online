using System;
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
        public string clientName = "";
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
                        case PacketType.CLIENT_LIST:
                            ClientListPacket clientListPacket = (ClientListPacket)packet;
                            paintForm.UpdatePlayerList( clientListPacket.name, clientListPacket.removeText );
                            break;
                        case PacketType.PEN:
                            PenPacket penPacket = (PenPacket)packet;
                            paintForm.UpdatePen( penPacket.penColor );
                            break;
                        case PacketType.CLEAR_GLOBAL:
                            paintForm.ClearCanvas();
                            break;
                        case PacketType.CLEAR_SINGLE:
                            ClearSinglePacket clearSinglePacket = (ClearSinglePacket)packet;
                            if ( clearSinglePacket.playerName == clientName )
                                paintForm.ClearCanvas();
                            break;
                        case PacketType.ADMIN:
                            AdminPacket adminPacket = (AdminPacket)packet;
                            paintForm.adminConnected = adminPacket.adminConnected;
                            break;
                        case PacketType.ENABLE_PAINTING:
                            EnablePaintingPacket enablePainting = (EnablePaintingPacket)packet;
                            if ( enablePainting.playerName == clientName )
                                paintForm.penEnabled = enablePainting.enablePainting;
                            break;
                    }
                }
            }
            catch( Exception exception )
            {
                Console.WriteLine( "Client TCP Read Method Exception: " + exception.Message );
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
                        case PacketType.PAINT:
                            PaintPacket paintPacket = (PaintPacket)packet;
                            paintForm.UpdateCanvas( paintPacket.xPos, paintPacket.yPos, paintPacket.mouseLocation );
                            break;
                    }
                }
            }
            catch( SocketException exception )
            {
                Console.WriteLine( "Client UDP Read Method Exception: " + exception.Message );
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
