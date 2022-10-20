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
}