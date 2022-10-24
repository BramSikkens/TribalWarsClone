﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TribalWarsCloneDomain.Interfaces;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public interface IHeadQuarters : IUpgradable
    {

    }

    public class HeadQuarters : Building, IHeadQuarters
    {
        public int MaxLevel { get; set; }
        public Cost ProductionCost { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Cost DestructionReturn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
  

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
    }
}
