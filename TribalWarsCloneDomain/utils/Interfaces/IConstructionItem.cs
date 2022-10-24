using System;
using TribalWarsCloneDomain.Models;

namespace TribalWarsCloneDomain.Interfaces
{
    public interface IConstructionItem : IPrint
    {
        public System.Timers.Timer Timer { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public String Status { get; set; }
        public String Title { get; set; }
        public Cost Cost { get; set; }

        public void StartItemTimer();
    }
}

