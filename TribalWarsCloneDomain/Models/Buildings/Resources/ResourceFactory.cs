using System;
using System.Timers;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public abstract class ResourceFactory: Building, IUpgradable
    {

        public int MaxLevel { get; set; }
        public Cost ProductionCost { get; set; }
        public Cost DestructionReturn { get; set; }

        public Farm Farm { get; set; }
        public Warehouse Warehouse { get; set; }

        public ResourceFactory(Cost initialCost, int maxLevel, Farm farm, Warehouse warehouse)
        {
            CurrentLevel = 1;
            MaxLevel = maxLevel;
            ProductionCost = initialCost;

            //Overal moet ik precies Farm en Warehouse meegeven?
            //Kan dit anders;
            Warehouse = warehouse;
            Farm = farm;
     
        }


        public void downgrade()
        {
            throw new NotImplementedException();
        }

        public void upgrade(ConstructionList buildList)
        {
            Boolean enoughResources = Warehouse.checkEnoughResources(ProductionCost);
            Boolean enoughVillagers = Farm.checkEnoughResources(ProductionCost);

            //First we check if there is enough in the warehouse
            if (enoughResources && enoughVillagers)
            {
                //We create a buildTask(ITem) 
                ConstructionItem bi = new ConstructionItem(this.ProductionCost, onUpgradeComplete);
                //And add it to the given list
                buildList.AddItem(bi);
                //Remove cost from Warehouse
                Warehouse.withdrawResources(ProductionCost.ClayCost, ProductionCost.IronCost, ProductionCost.WoodCost);
                Farm.withdrawPopulation(ProductionCost.VillagerCost);

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

