using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TribalWarsClone.Models.Buildings
{
    internal interface IUpgradable
    {
        int MaxLevel { get;  }
        public ProductionCost ProductionCost { get; set; }
        public ProductionCost DestructionReturn { get; set; }

        void upgrade(BuildList buildList);
        void downgrade();

    }
}
