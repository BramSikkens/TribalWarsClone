using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public class ClayPit : ResourceBuilding,IUpgradable
    {
   

        public ClayPit(Cost initialCost, int maxLevel,Farm farm, Warehouse warehouse):base(initialCost,maxLevel,farm,warehouse)
        {

            Gain = 1;
        }

        public override void onUpgradeComplete(Object source, ElapsedEventArgs e)
        {
            base.onUpgradeComplete(source, e);
            Gain++;
            Console.WriteLine("ClayPit Upgraded");
            //Notify observers that I am upgraded
            Notify();





        }




    }
}
