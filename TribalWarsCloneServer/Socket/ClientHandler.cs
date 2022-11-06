using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TribalWarsCloneDomain.utils;
using TribalWarsCloneServer.Socket.Messages;

namespace TribalWarsCloneServer.Socket
{
    public class ClientHandler:ISubject
    {
        TcpClient clientSocket;
        string clNo;

        public List<IObserver> Observers { get; set; } = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            this.Observers.Add(observer);
        }

        public void Notify(SocketMessage message)
        {
          
            foreach(IObserver o in Observers)
            {
                o.Update(message);
            }
        }

        public void startClient(TcpClient inClientSocket, string clineNo)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
            Thread ctThread = new Thread(consumeMessage);
            ctThread.Start();
        }

        public void UnAttach(IObserver observer)
        {
            throw new NotImplementedException();
        }

        private void consumeMessage()
        {
            int requestCount = 0;
            byte[] bytesFrom = new byte[this.clientSocket.ReceiveBufferSize];
            string dataFromClient = null;
            Byte[] sendBytes = null;
            string serverResponse = null;
            string rCount = null;
            requestCount = 0;

            while ((true))
            {
                try
                {
                    requestCount = requestCount + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));


                    SocketMessage message = JsonSerializer.Deserialize<SocketMessage>(dataFromClient);
                    Notify(message);
                    //Console.WriteLine("Message from {0}: {1}", message.from, message.message);



                }
                catch (Exception ex)
                {
                    Console.WriteLine(" >> " + ex.ToString());
                }
            }


        }


    }
}
