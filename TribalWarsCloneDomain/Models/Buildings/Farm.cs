using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TribalWarsCloneDomain.Interfaces;
using TribalWarsCloneDomain.utils;
using TribalWarsCloneDomain.utils.Interfaces;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public interface IFarm: IUpgradable,IPrint,IResourceble
    {

        public int PopulationInFarm { get; set; }
        public int PopulationCount { get; set; }

    

    }


    public class Farm : Building,IFarm
    {
        public int MaxLevel { get; }
        public int PopulationCount { get; set; }
        public int PopulationInFarm { get; set; }
        public Cost ProductionCost { get; set; }
        public Cost DestructionReturn { get; set; }
        public IWarehouse Warehouse { get; set; }

        public Farm(Cost initialCost)
        {
            CurrentLevel = 1;
            MaxLevel = 20; 
            PopulationCount = 240;
            PopulationInFarm = 240;
            ProductionCost = initialCost;
        }

        public void Downgrade()
        {
            throw new NotImplementedException();
        }

      
        public void Upgrade(IConstructionList buildList)
        {
            //First we check if there is enough in the warehouse
            if (Warehouse.CheckEnoughResources(ProductionCost))
            {
                //We create a buildTask(ITem) 
                ConstructionItem bi = new ConstructionItem(this.ProductionCost, WhenUpgradeIsComplete);
                //And add it to the given list
                buildList.AddItem(bi);
                //Remove cost from Warehouse
                Warehouse.WithdrawResources(ProductionCost);
            }
            else
            {
                Console.WriteLine("Not enough Resources");
            }
        }

        public void WithdrawResources(Cost cost)
        {
            PopulationInFarm = PopulationInFarm - cost.VillagerCost;
        }

        public Boolean CheckEnoughResources(Cost cost)
        {
            if (cost.VillagerCost > PopulationInFarm)
            {
                return false;
            }
            return true;
        }


        public void WhenUpgradeIsComplete(object source, ElapsedEventArgs e)
        {
            CurrentLevel++;
            DestructionReturn = ProductionCost;
            PopulationCount += 100;
            PopulationInFarm += 100;
            PopulationInFarm += ProductionCost.VillagerCost;

            Console.WriteLine("Farm Upgraded");
            ProductionCost.ClayCost = (int)Math.Round(ProductionCost.ClayCost * 1.5);
            ProductionCost.IronCost = (int)Math.Round(ProductionCost.IronCost * 1.5);
            ProductionCost.WoodCost = (int)Math.Round(ProductionCost.WoodCost * 1.5);
            ProductionCost.ProductionTime = (int)Math.Round(ProductionCost.ProductionTime * 1.5);
        }

    
        public void Print()
        {
            Console.WriteLine("MaxPopulation: {0} | Population in farm: {1}", PopulationCount, PopulationInFarm);
        }

        public void UpdateResources()
        {
            throw new NotImplementedException();
        }

   
    }
}
