using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TribalWarsCloneDomain.Interfaces;
using TribalWarsCloneDomain.utils.Interfaces;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public interface IHeadQuarters : IUpgradable
    {

    }

    public class HeadQuarters : Building, IHeadQuarters
    {
        public int MaxLevel { get; set; }
        public Dictionary<int, Cost> ProductionCostsPerLevel { get; set; }

        public HeadQuarters()
        {
            CurrentLevel = 1;
            MaxLevel = 20;
        }

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
