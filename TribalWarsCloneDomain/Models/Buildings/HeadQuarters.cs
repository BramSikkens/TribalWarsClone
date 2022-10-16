using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public class HeadQuarters : Building, IUpgradable
    {
        public int MaxLevel { get; set; }
        public Cost ProductionCost { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Cost DestructionReturn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Farm Farm { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Warehouse Warehouse { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public HeadQuarters()
        {
            CurrentLevel = 1;
            MaxLevel = 20;
        }

        public void downgrade()
        {
            throw new NotImplementedException();
        }

 
        public void upgrade(ConstructionList buildList,Warehouse warehouse, Farm farm)
        {
            throw new NotImplementedException();
        }

        public void onUpgradeComplete(object source, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void upgrade(ConstructionList buildList)
        {
            throw new NotImplementedException();
        }
    }
}
