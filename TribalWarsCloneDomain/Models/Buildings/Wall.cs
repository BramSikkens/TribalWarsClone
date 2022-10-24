using System;
using System.Timers;
using TribalWarsCloneDomain.Interfaces;

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
        public Cost ProductionCost { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Cost DestructionReturn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
    }
}

