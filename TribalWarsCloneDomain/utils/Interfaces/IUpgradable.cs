using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TribalWarsCloneDomain.Interfaces;
using TribalWarsCloneDomain.Models;

namespace TribalWarsCloneDomain.utils.Interfaces
{
    public interface IUpgradable
    {
   
        int CurrentLevel { get; set; }
        //Dictionary<int, Cost> ProductionCostsPerLevel { get; set; }

        void Upgrade(IConstructionList buildList);
        void WhenUpgradeIsComplete(object source, ElapsedEventArgs e);
        void Downgrade();
        Cost GetLevelCost(int level);

    }
}
