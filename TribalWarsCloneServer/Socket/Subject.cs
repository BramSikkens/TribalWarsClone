using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TribalWarsCloneServer.Socket.Messages;

namespace TribalWarsCloneServer.Socket
{
    public interface ISubject
    {
        public List<IObserver> Observers { get; set; }
        public void Attach(IObserver observer);
        public void UnAttach(IObserver observer);
        public void Notify(SocketMessage message);
    }

  
}
