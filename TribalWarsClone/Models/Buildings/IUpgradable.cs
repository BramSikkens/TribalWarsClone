﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TribalWarsClone.Models.Buildings
{
    internal interface IUpgradable
    {
        public int MaxLevel { get;  }
        public Cost ProductionCost { get; set; }
        public Cost DestructionReturn { get; set; }

        void upgrade(BuildList buildList,Warehouse warehouse);
        void downgrade();

    }
}
