using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TribalWarsCloneServer.Socket.Messages
{
    public struct SocketMessage
    {
        public string from { get; set; }
        public string message { get; set; }
    }
}
