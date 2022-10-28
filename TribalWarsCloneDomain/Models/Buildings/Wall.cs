using System;
using System.Collections.Generic;
using System.Timers;
using TribalWarsCloneDomain.Interfaces;
using TribalWarsCloneDomain.utils.Interfaces;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public class Wall:Building,IUpgradable
    {
        public Wall()
        {
        }

        public int MaxLevel => throw new NotImplementedException();
        public IFarm Farm { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IWarehouse Warehouse { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Dictionary<int, Cost> ProductionCostsPerLevel { get; set; }

        public void Downgrade()
        {
            throw new NotImplementedException();
        }

        public void WhenUpgradeIsComplete(object source, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Upgrade(IConstructionList buildList)
        {
            throw new NotImplementedException();
        }

        public Cost GetLevelCost(int level)
        {
            throw new NotImplementedException();
        }
    }
}

