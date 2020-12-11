using System;
using System.IO;
using System.Net;
using System.Drawing;
using System.Threading;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server
{
    class Server
    {
        private int index;
        private Color startColor;
        private UdpClient udpListener;
        private TcpListener tcpListerer;
        private List<string> clientNames;
        private bool adminIsConnected = false;
        private ConcurrentDictionary<int, Client> clients;

        public Server( string ipAddress, int port )
        {
            IPAddress localAddress = IPAddress.Parse( ipAddress );
            tcpListerer = new TcpListener( localAddress, port );
            udpListener = new UdpClient( port );
            clientNames = new List<string>();
            clientNames.Add( "Empty" );
        }

        public void Start()
        {
            clients = new ConcurrentDictionary<int, Client>();
            tcpListerer.Start();

            int clientID = 0;
            while( true )
            {
                index = clientID;
                clientID++;

                Socket socket = tcpListerer.AcceptSocket();

                Client client = new Client( socket );
                clients.TryAdd( index, client );

                Thread tcpThread = new Thread( () => { TcpClientMethod( client ); } );
                tcpThread.Start();
                
                Thread udpThread = new Thread( () => { UdpListen(); } );
                udpThread.Start();
            }
        }

        public void Stop()
        {
            tcpListerer.Stop();
        }

        private void TcpClientMethod( Client client )
        {
            try
            {
                Packet packet;
                while ( ( packet = client.TcpRead() ) != null )
                {
                    if ( packet != null )
                    {
                        switch ( packet.packetType )
                        {
                            case PacketType.LOGIN:
                                LoginPacket loginPacket = (LoginPacket)packet;
                                clients[index - 1].endPoint = loginPacket.EndPoint;
                                clients[index - 1].ClientKey = loginPacket.PublicKey;
                                client.TcpSend( new LoginPacket( null, client.PublicKey ) );
                                client.TcpSend( new PenPacket( startColor ) );
                                foreach ( KeyValuePair<int, Client> c in clients )
                                {
                                    if ( c.Value != client )
                                        c.Value.TcpSend( new PenPacket( Color.Black ) );

                                    for ( int i = 0; i < clientNames.Count; i++ )
                                    {
                                        if ( i == 0 )
                                            c.Value.TcpSend( new EncryptedClientListPacket( c.Value.EncryptString( clientNames[i] ),
                                                BitConverter.GetBytes( true ) ) );
                                        else
                                            c.Value.TcpSend( new EncryptedClientListPacket( c.Value.EncryptString( clientNames[i] ),
                                                BitConverter.GetBytes( false ) ) );
                                    }

                                    c.Value.TcpSend( new EncryptedAdminPacket( BitConverter.GetBytes( adminIsConnected ) ) );
                                }
                                break;
                            case PacketType.ENCRYPTED_ADMIN:
                                EncryptedAdminPacket adminPacket = (EncryptedAdminPacket)packet;
                                adminIsConnected = BitConverter.ToBoolean( adminPacket.adminConnected, 0 );
                                foreach ( KeyValuePair<int, Client> c in clients )
                                    c.Value.TcpSend( adminPacket );
                                break;
                            case PacketType.ENCRYPTED_CLIENT_LIST:
                                EncryptedClientListPacket clientListPacket = (EncryptedClientListPacket)packet;
                                string clientListName = client.DecryptString( clientListPacket.name );
                                bool clientListBool = BitConverter.ToBoolean( clientListPacket.removeText, 0 );
                                if ( !clientListBool )
                                    clientNames.Add( clientListName );
                                else
                                    clientNames.Remove( clientListName );
                                foreach ( KeyValuePair<int, Client> c in clients )
                                {
                                    for ( int i = 0; i < clientNames.Count; i++ )
                                    {
                                        if ( i == 0 )
                                            c.Value.TcpSend( new EncryptedClientListPacket( c.Value.EncryptString( clientNames[i] ),
                                                BitConverter.GetBytes( true ) ) );
                                        else
                                            c.Value.TcpSend( new EncryptedClientListPacket( c.Value.EncryptString( clientNames[i] ),
                                                BitConverter.GetBytes( false ) ) );
                                    }
                                }
                                break;
                            case PacketType.PEN:
                                PenPacket penPacket = (PenPacket)packet;
                                startColor = penPacket.penColor;
                                foreach ( KeyValuePair<int, Client> c in clients )
                                    c.Value.TcpSend( penPacket );
                                break;
                            case PacketType.ENCRYPTED_ENABLE_PAINTING:
                                EncryptedEnablePaintingPacket enablePaintingPacket = (EncryptedEnablePaintingPacket)packet;
                                string enablePaintingString = client.DecryptString( enablePaintingPacket.playerName );
                                bool enablePaintingBool = BitConverter.ToBoolean( enablePaintingPacket.enablePainting, 0 );
                                foreach ( KeyValuePair<int, Client> c in clients )
                                    if ( c.Value != client )
                                        c.Value.TcpSend( new EncryptedEnablePaintingPacket( c.Value.EncryptString( enablePaintingString ),
                                            BitConverter.GetBytes( enablePaintingBool ) ) );
                                break;
                            case PacketType.CLEAR_SINGLE:
                                ClearSinglePacket clearSinglePacket = (ClearSinglePacket)packet;
                                foreach ( KeyValuePair<int, Client> c in clients )
                                    if ( c.Value != client )
                                        c.Value.TcpSend( clearSinglePacket );
                                break;
                            case PacketType.CLEAR_GLOBAL:
                                ClearGlobalPacket clearGlobalPacket = (ClearGlobalPacket)packet;
                                foreach ( KeyValuePair<int, Client> c in clients )
                                    c.Value.TcpSend( clearGlobalPacket );
                                break;
                        }
                    }
                }
            }
            catch ( Exception exception )
            {
                Console.WriteLine( "Server TCP Read Method Exception: " + exception.Message );
            }
            finally
            {
                client.Close();
                clients.TryRemove( index, out client );
            }
        }

        private void UdpListen()
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint( IPAddress.Any, 0 );
                while( true )
                {
                    byte[] bytes = udpListener.Receive( ref endPoint );
                    MemoryStream memoryStream = new MemoryStream( bytes );
                    Packet packet = new BinaryFormatter().Deserialize( memoryStream ) as Packet;
                    foreach( KeyValuePair<int, Client> c in clients )
                    {
                        if ( endPoint.ToString() != c.Value.endPoint.ToString() )
                        {
                            switch ( packet.packetType )
                            {
                                case PacketType.PAINT:
                                    PaintPacket paintPacket = (PaintPacket)packet;
                                    UdpSend( c.Value, paintPacket );
                                    break;
                            }
                        }
                    }
                }
            }
            catch( SocketException e )
            {
                Console.WriteLine( "Server UDP Read Method Exception: " + e.Message );
            }
        }

        private void UdpSend( Client client, Packet packet )
        {
            MemoryStream memoryStream = new MemoryStream();
            new BinaryFormatter().Serialize( memoryStream, packet );
            byte[] buffer = memoryStream.GetBuffer();
            udpListener.Send( buffer, buffer.Length, client.endPoint );
            memoryStream.Close();
        }
    }
}
