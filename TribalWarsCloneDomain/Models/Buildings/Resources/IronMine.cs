using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TribalWarsCloneDomain.utils;
using TribalWarsCloneDomain.utils.Interfaces;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public class IronMine : ResourceBuilding, IUpgradable
    {

        public IronMine(Dictionary<int,Cost> initialCost, int maxLevel, IFarm farm, IWarehouse warehouse) : base(initialCost, maxLevel, farm, warehouse)
        {

            Gain = 1;
      
        }

        public override void WhenUpgradeIsComplete(Object source, ElapsedEventArgs e)
        {
        
            base.WhenUpgradeIsComplete(source, e);
            Console.WriteLine("IronMine Upgraded");
            //Notify observers that I am upgraded
            Notify();

        }


       
    }
}
