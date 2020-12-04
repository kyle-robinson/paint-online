using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            if ( client.Connect( "127.0.0.1", 4444 ) == true )
            {
                client.Run();
            }
            else
            {
                Console.WriteLine( "Failed to connect client to the server." );
            }
        }
    }
}
