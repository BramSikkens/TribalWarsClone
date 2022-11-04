using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using TribalWarsCloneDomain.Interfaces;

namespace TribalWarsCloneDomain.Models.Soldiers
{
    public class SpearSoldier : Soldier
    {
        public SpearSoldier(SoldierStats stats):base(stats)
        {

        }

        public override void Downgrade()
        {
            throw new NotImplementedException();
        }

        public override Cost GetLevelCost(int level)
        {
            throw new NotImplementedException();
        }

        public override void Upgrade(IConstructionList buildList)
        {
            throw new NotImplementedException();
        }

        public override void WhenUpgradeIsComplete(object source, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
