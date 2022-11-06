using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TribalWarsCloneServer.Socket.Messages;

namespace TribalWarsCloneServer.Socket
{
    public interface IObserver
    {
        public void Update(SocketMessage message);
    }

}
