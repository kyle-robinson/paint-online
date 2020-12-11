using System;
using System.IO;
using System.Net;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Net.Sockets;
using System.Security.Cryptography;
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
        private RSACryptoServiceProvider RSAProvider;
        private RSAParameters ServerKey;
        private RSAParameters PublicKey;
        private RSAParameters PrivateKey;

        public Client()
        {
            tcpClient = new TcpClient();
            udpClient = new UdpClient();
            RSAProvider = new RSACryptoServiceProvider( 2048 );
            PublicKey = RSAProvider.ExportParameters( false );
            PrivateKey = RSAProvider.ExportParameters( true );
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
                Console.WriteLine( "Client Connect Exception: " + exception.Message );
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

                TcpSendMessage( new LoginPacket( (IPEndPoint)udpClient.Client.LocalEndPoint, PublicKey ) );

                paintForm.ShowDialog();
            }
            catch( Exception exception )
            {
                Console.WriteLine( "Client Run Exception: " + exception.Message );
            }
            finally
            {
                tcpClient.Close();
                udpClient.Close();
            }
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
                        case PacketType.LOGIN:
                            Console.WriteLine( "Client [" + clientName + "] TCP 'Login' Packet Received" );
                            LoginPacket loginPacket = (LoginPacket)packet;
                            ServerKey = loginPacket.PublicKey;
                            break;
                        case PacketType.ENCRYPTED_ADMIN:
                            Console.WriteLine( "Client [" + clientName + "] TCP 'Admin' Packet Received" );
                            EncryptedAdminPacket adminPacket = (EncryptedAdminPacket)packet;
                            paintForm.adminConnected = BitConverter.ToBoolean( adminPacket.adminConnected, 0 );
                            break;
                        case PacketType.ENCRYPTED_CLIENT_LIST:
                            Console.WriteLine( "Client [" + clientName + "] TCP 'Client List' Packet Received" );
                            EncryptedClientListPacket clientListPacket = (EncryptedClientListPacket)packet;
                            paintForm.UpdatePlayerList( DecryptString( clientListPacket.name ), BitConverter.ToBoolean( clientListPacket.removeText, 0 ) );
                            break;
                        case PacketType.PEN:
                            Console.WriteLine( "Client [" + clientName + "] TCP 'Pen' Packet Received" );
                            PenPacket penPacket = (PenPacket)packet;
                            paintForm.UpdatePen( penPacket.penColor );
                            break;
                        case PacketType.ENCRYPTED_ENABLE_PAINTING:
                            Console.WriteLine( "Client [" + clientName + "] TCP 'Enable Painting' Packet Received" );
                            EncryptedEnablePaintingPacket enablePaintingPacket = (EncryptedEnablePaintingPacket)packet;
                            string enablePaintingString = DecryptString( enablePaintingPacket.playerName );
                            bool enablePaintingBool = BitConverter.ToBoolean( enablePaintingPacket.enablePainting, 0 );
                            if ( enablePaintingString == clientName )
                            {
                                paintForm.penEnabled = enablePaintingBool;
                                if ( enablePaintingBool == true )
                                    paintForm.UpdateServerWindow( "Admin has enabled painting!", Color.Black, Color.SkyBlue );
                                else
                                    paintForm.UpdateServerWindow( "Admin has disabled painting!", Color.Black, Color.IndianRed );
                            }
                            break;
                        case PacketType.ENCRYPTED_CLEAR_SINGLE:
                            Console.WriteLine( "Client [" + clientName + "] TCP 'Clear Single' Packet Received" );
                            EncryptedClearSinglePacket clearSinglePacket = (EncryptedClearSinglePacket)packet;
                            string clearSingleString = DecryptString( clearSinglePacket.playerName );
                            if ( clearSingleString == clientName )
                            {
                                paintForm.UpdateServerWindow( "Admin cleared the canvas!", Color.Black, Color.IndianRed );
                                paintForm.ClearCanvas();
                            }
                            break;
                        case PacketType.CLEAR_GLOBAL:
                            Console.WriteLine( "Client [" + clientName + "] TCP 'Clear Global' Packet Received" );
                            paintForm.ClearCanvas();
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

        private byte[] Encrypt( byte[] data )
        {
            lock( RSAProvider )
            {
                RSAProvider.ImportParameters( ServerKey );
                return RSAProvider.Encrypt( data, true );
            }
        }

        private byte[] Decrypt( byte[] data )
        {
            lock( RSAProvider )
            {
                RSAProvider.ImportParameters( PrivateKey );
                return RSAProvider.Decrypt( data, true );
            }
        }

        public byte[] EncryptString( string message )
        {
            return Encrypt( Encoding.UTF8.GetBytes( message ) );
        }

        public string DecryptString( byte[] message )
        {
            return Encoding.UTF8.GetString( Decrypt( message ) );
        }
    }
}
