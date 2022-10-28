﻿using System;
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
    public interface IFarm: IUpgradable,IPrint,IResourcable
    {

        public int PopulationInFarm { get; set; }
        public int PopulationCount { get; set; }

    

    }


    public class Farm : Building,IFarm
    {
        public int MaxLevel { get; }
        public int PopulationCount { get; set; }
        public int PopulationInFarm { get; set; }
        public IWarehouse Warehouse { get; set; }

        public Dictionary<int, Cost> ProductionCostsPerLevel { get; set; }

        public Farm(Dictionary<int, Cost> productionCosts)
        {
            CurrentLevel = 1;
            MaxLevel = 20; 
            PopulationCount = 240;
            PopulationInFarm = 240;
            ProductionCostsPerLevel = productionCosts;
        }

        public void Downgrade()
        {
            throw new NotImplementedException();
        }

      
        public void Upgrade(IConstructionList buildList)
        {
            //First we check if there is enough in the warehouse
            if (Warehouse.CheckEnoughResources(GetLevelCost(CurrentLevel++)))
            {
                //We create a buildTask(ITem) 
                ConstructionItem bi = new ConstructionItem(GetLevelCost(CurrentLevel++), WhenUpgradeIsComplete);
                //And add it to the given list
                buildList.AddItem(bi);
                //Remove cost from Warehouse
                Warehouse.WithdrawResources(GetLevelCost(CurrentLevel++));
            }
            else
            {
                Console.WriteLine("Not enough EssentialResources");
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
 
            PopulationCount += 100;
            PopulationInFarm += 100;
            PopulationInFarm += GetLevelCost(CurrentLevel).VillagerCost;

            Console.WriteLine("Farm Upgraded");
        }

    
        public void Print()
        {
            Console.WriteLine("MaxPopulation: {0} | Population in farm: {1}", PopulationCount, PopulationInFarm);
        }

        public void UpdateResources()
        {
            throw new NotImplementedException();
        }

        public Cost GetLevelCost(int level)
        {
            return ProductionCostsPerLevel[level];
        }
    }
}
