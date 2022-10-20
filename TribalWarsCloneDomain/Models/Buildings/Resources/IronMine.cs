﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TribalWarsCloneDomain.utils;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public class IronMine : ResourceBuilding, IUpgradable
    {

        public IronMine(Cost initialCost, int maxLevel, Farm farm, Warehouse warehouse) : base(initialCost, maxLevel, farm, warehouse)
        {

            Gain = 1;
      
        }

        public override void onUpgradeComplete(Object source, ElapsedEventArgs e)
        {
        
            base.onUpgradeComplete(source, e);
            Console.WriteLine("IronMine Upgraded");
            //Notify observers that I am upgraded
            Notify();

        }


       
    }
}
