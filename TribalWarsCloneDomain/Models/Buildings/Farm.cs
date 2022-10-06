using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public class Farm : Building, IUpgradable
    {
        public int MaxLevel { get; }
        public int PopulationCount { get; set; }
        public int PopulationInFarm { get; set; }
        public Cost ProductionCost { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Cost DestructionReturn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Farm()
        {
            CurrentLevel = 1;
            MaxLevel = 20; 
            PopulationCount = 240;
            PopulationInFarm = 240;
        }

        public void downgrade()
        {
            throw new NotImplementedException();
        }

      
        public void upgrade(BuildList buildList,Warehouse warehouse,Farm farm)
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

        public void withdrawPopulation(int populationAmount)
        {
            
        }

        public void onUpgradeComplete(object source, ElapsedEventArgs e)
        {
            CurrentLevel++;
            PopulationCount += 100;
            PopulationInFarm += 100;
            PopulationInFarm += ProductionCost.VillagerCost;

            Console.WriteLine("Farm Upgraded");
            ProductionCost.ClayCost = (int)Math.Round(ProductionCost.ClayCost * 1.5);
            ProductionCost.IronCost = (int)Math.Round(ProductionCost.IronCost * 1.5);
            ProductionCost.WoodCost = (int)Math.Round(ProductionCost.WoodCost * 1.5);
            ProductionCost.ProductionTime = (int)Math.Round(ProductionCost.ProductionTime * 1.5);
        }

        public void printFarmInfo()
        {
            Console.WriteLine("MaxPopulation: {0} | Population in farm: {1}", PopulationCount, PopulationInFarm);
        }
       
    }
}
