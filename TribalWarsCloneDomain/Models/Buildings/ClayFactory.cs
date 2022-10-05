using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public class ClayFactory : Building,IUpgradable
    {
        public int MaxLevel { get; }
        public Cost ProductionCost { get; set; }
        public Cost DestructionReturn { get; set; }


        public ClayFactory(Cost initialCost, int maxLevel)
        {
            CurrentLevel = 0;
            ProductionCost = initialCost;
            MaxLevel = maxLevel;
        }

        public void downgrade()
        {
            throw new NotImplementedException();
        }

        public void onUpgradeComplete(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("IronFactory Upgraded");
            CurrentLevel++;
            ProductionCost.ClayCost = (int)Math.Round(ProductionCost.ClayCost * 1.5);
            ProductionCost.IronCost = (int)Math.Round(ProductionCost.IronCost * 1.5);
            ProductionCost.WoodCost = (int)Math.Round(ProductionCost.WoodCost * 1.5);
            ProductionCost.ProductionTime = (int)Math.Round(ProductionCost.ProductionTime * 1.5);

        }

        //When upgrading we put the building in a buildlist and take out resources out of the warehouse
        public void upgrade(BuildList buildList, Warehouse warehouse)
        {
            //First we check if there is enough in the warehouse
            if (warehouse.checkEnoughResources(ProductionCost))
            {
                //We create a buildTask(ITem) 
                BuildItem bi = new BuildItem(this.ProductionCost, onUpgradeComplete);
                //And add it to the given list
                buildList.AddItem(bi);
            }
            else
            {
                Console.WriteLine("Not enough Resources");
            }

        
       

        }


        public void printStats()
        {
            Console.WriteLine("CurrentLevel:" + CurrentLevel);
            Console.WriteLine("Clay Cost Upgrade:" + ProductionCost.ClayCost);
            Console.WriteLine("Iron Cost Upgrade:" + ProductionCost.IronCost);
            Console.WriteLine("Wood Cost Upgrade:" + ProductionCost.WoodCost);
        }
    }
}
