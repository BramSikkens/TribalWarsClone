using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TribalWarsCloneDomain.utils;

namespace TribalWarsCloneServer.Socket
{
    public class TcpSocketServer
    {
        private static TcpListener listener { get; set; }
        private static bool accept { get; set; } = false;

        public  void StartServer(int port)
        {
            IPAddress address = IPAddress.Parse("127.0.0.1");
            listener = new TcpListener(address, port);
            listener.Start();
            accept = true;
            Console.WriteLine($"Server Socket started. Listening to TCP clients at 127.0.0.1:{port}");
        }

        public async Task Listen()
        {
            int counter = 0;

            if (listener != null && accept)
            {

                // Continue listening.  
                while (true)
                {
                    counter += 1;
                    TcpClient client = await listener.AcceptTcpClientAsync(); // Get the client  
                    ClientHandler clientHandler = new ClientHandler();
                    (clientHandler as ISubject).Attach(Game.Instance);
                    clientHandler.startClient(client, Convert.ToString(counter));
                }

                //client.Close();
                listener.Stop();
                Console.WriteLine(" >> " + "exit");
                Console.ReadLine();
            }
        }
    }
}
