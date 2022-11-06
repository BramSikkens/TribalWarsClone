using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TribalWarsCloneDomain.Interfaces;
using TribalWarsCloneDomain.utils.Interfaces;
using TribalWarsCloneDomain.utils.JSONWorldSettings;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public class ClayPit : ResourceBuilding,IUpgradable
    {
   
        public ClayPit(IFarm farm, IWarehouse warehouse):base(farm,warehouse)
        {
            Gain = 1;
        }

        public override void WhenUpgradeIsComplete(Object source, ElapsedEventArgs e)
        {
            base.WhenUpgradeIsComplete(source, e);
            Gain++;
            Console.WriteLine("ClayPit Upgraded");
            //Notify observers that I am upgraded
            Notify();

        }

        public override Cost GetLevelCost(int level)
        {
            return WorldSettings.ClayPitProductionCosts[level.ToString()];

        }

        public override void Upgrade(IConstructionList buildlist)
        {
            if (CurrentLevel == WorldSettings.TimberCampMaxLevel)
            {
                Console.WriteLine("Cannot upgrade anymore");
                return;
            }

            base.Upgrade(buildlist);
        }

    }
}
