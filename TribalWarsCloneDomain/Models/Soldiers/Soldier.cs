using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using TribalWarsCloneDomain.Interfaces;
using TribalWarsCloneDomain.utils.Interfaces;

namespace TribalWarsCloneDomain.Models.Soldiers
{
    public abstract class Soldier:IUpgradable
    {
        public SoldierStats Stats { get; set; }
        public int CurrentLevel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Soldier(SoldierStats stats)
        {
           
          Stats=stats;
        }

        public abstract void Upgrade(IConstructionList buildList);

        public abstract void WhenUpgradeIsComplete(object source, ElapsedEventArgs e);

        public abstract void Downgrade();

        public abstract Cost GetLevelCost(int level);
  
    }
}
