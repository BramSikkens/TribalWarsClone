using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace TribalWarsCloneDomain.utils
{
    public interface IObserver
    {
        public void Update(ISubject subject);
    }

    public interface IObserverSmitthy
    {
        public void UpdateRallyPoin(string type, int amount);
    }
}
