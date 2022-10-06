using System;
using System.Timers;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public abstract class ResourceFactory: Building, IUpgradable
    {

        public int MaxLevel { get; set; }
        public Cost ProductionCost { get; set; }
        public Cost DestructionReturn { get; set; }


        public ResourceFactory(Cost initialCost,int maxLevel)
        {
            CurrentLevel = 1;
            MaxLevel = maxLevel;
            ProductionCost = initialCost;
     
        }


        public void downgrade()
        {
            throw new NotImplementedException();
        }

        public void upgrade(BuildList buildList, Warehouse warehouse, Farm farm)
        {
            //First we check if there is enough in the warehouse
            if (warehouse.checkEnoughResources(ProductionCost))
            {
                //We create a buildTask(ITem) 
                ConstructionItem bi = new ConstructionItem(this.ProductionCost, onUpgradeComplete);
                //And add it to the given list
                buildList.AddItem(bi);
                //Remove cost from Warehouse
                warehouse.withdrawResources(ProductionCost.ClayCost, ProductionCost.IronCost, ProductionCost.WoodCost);
            }
            else
            {
                Console.WriteLine("Not enough Resources");
            }
        }


        public abstract void onUpgradeComplete(Object source, ElapsedEventArgs e);

        public void printBuildingInfo()
        {
            Console.WriteLine("Level: {0}", CurrentLevel);
            Console.WriteLine("Upgrade Cost -> Iron:{0} | Wood:{1} | Clay:{2}", ProductionCost.IronCost, ProductionCost.WoodCost, ProductionCost.ClayCost);
        }
    }



}

