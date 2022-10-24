using System;
using System.Collections.Generic;
using System.Text;

namespace TribalWarsCloneDomain.utils
{
    public interface ISubject
    {
        public List<IObserver> Observers { get; set; }
        public void Attach(IObserver observer);
        public void UnAttach(IObserver observer);
        public void Notify();
    }

    public interface ISubjectSmithy
    {
        public List<IObserverSmitthy> SmitthyObservers { get; set; }
        public void Attach(IObserverSmitthy observer);
        public void UnAttach(IObserverSmitthy observer);
        public void NotifySoldierTrainingComplete(string type, int amount);
    }
}