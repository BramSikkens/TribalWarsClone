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


        public Farm Farm { get; set; }
        public Warehouse Warehouse { get; set; }


        public Cost ProductionCost { get; set; }
        public Cost DestructionReturn { get; set; }
    


        void upgrade(ConstructionList buildList);
        void onUpgradeComplete(Object source, ElapsedEventArgs e);
        void downgrade();

    }
}
