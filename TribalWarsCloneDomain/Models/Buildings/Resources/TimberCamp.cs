using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TribalWarsCloneDomain.utils.Interfaces;
using TribalWarsCloneDomain.utils.JSONWorldSettings;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public class TimberCamp : ResourceBuilding,IUpgradable
    {


        public TimberCamp(IFarm farm, IWarehouse warehouse) : base(farm, warehouse)
        {
            Gain = 1;
        }


        public override void WhenUpgradeIsComplete(Object source, ElapsedEventArgs e)
        {
            base.WhenUpgradeIsComplete(source, e);
            Gain++;
            Console.WriteLine("TimberCamp Upgraded");
            //Notify observers that I am upgraded
            Notify();
        }

        public override Cost GetLevelCost(int level)
        {
            return WorldSettings.TimberCampProductionCosts[level];

        }
    }
}
