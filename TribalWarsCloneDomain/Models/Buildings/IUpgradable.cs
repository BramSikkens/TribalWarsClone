using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public interface IUpgradable
    {
        int MaxLevel { get;  }
        public Cost ProductionCost { get; set; }
        public Cost DestructionReturn { get; set; }

        void upgrade(BuildList buildList,Warehouse warehouse,Farm farm);
        void onUpgradeComplete(Object source, ElapsedEventArgs e);
        void downgrade();

    }
}
