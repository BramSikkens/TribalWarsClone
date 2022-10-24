using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TribalWarsCloneDomain.Interfaces;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public interface IUpgradable
    {
        int MaxLevel { get; }
        int CurrentLevel { get; set; }

        public Cost ProductionCost { get; set; }
        public Cost DestructionReturn { get; set; }
    
        void Upgrade(IConstructionList buildList);
        void WhenUpgradeIsComplete(Object source, ElapsedEventArgs e);
        void Downgrade();

    }
}
