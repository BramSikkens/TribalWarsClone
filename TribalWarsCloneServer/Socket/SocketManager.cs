using TribalWarsCloneDomain.Models;
using TribalWarsCloneServer.Socket.Messages;

namespace TribalWarsCloneServer.Socket
{
    public class SocketManager 
    {
        public SocketManager()
        {
            ////Setup Socket Server
            TcpSocketServer TcpSocketServer = new TcpSocketServer();
            TcpSocketServer.StartServer(443);
            TcpSocketServer.Listen();
        }

        

      
    }

}
