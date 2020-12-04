using System;
using System.IO;
using System.Net;
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
        private UdpClient udpListener;
        private TcpListener tcpListerer;
        private ConcurrentDictionary<int, Client> clients;

        public Server( string ipAddress, int port )
        {
            IPAddress localAddress = IPAddress.Parse( ipAddress );
            tcpListerer = new TcpListener( localAddress, port );
            udpListener = new UdpClient( port );
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
                        Console.WriteLine( "Received" );
                        switch ( packet.packetType )
                        {
                            case PacketType.EMPTY:
                                break;
                            case PacketType.LOGIN:
                                LoginPacket loginPacket = (LoginPacket)packet;
                                clients[index - 1].endPoint = loginPacket.EndPoint;
                                break;
                        }
                    }
                }
            }
            catch ( Exception exception )
            {
                Console.WriteLine( "EXCEPTION: " + exception.Message );
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
                    Console.WriteLine( "UPD Receive" );
                    foreach( KeyValuePair<int, Client> c in clients )
                        if ( endPoint.ToString() != c.Value.endPoint.ToString() )
                        {
                            // Do stuff with other clients
                        }
                        else
                        {
                            Console.WriteLine( "Matching EndPoints!" );
                        }
                    udpListener.Send( bytes, bytes.Length, endPoint );
                }
            }
            catch( SocketException e )
            {
                Console.WriteLine( "Client UDP Read Method Exception: " + e.Message );
            }
        }
    }
}
