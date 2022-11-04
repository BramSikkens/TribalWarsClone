using System;
using System.Collections.Generic;
using System.Timers;
using TribalWarsCloneDomain.Interfaces;
using TribalWarsCloneDomain.utils;
using TribalWarsCloneDomain.utils.Interfaces;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public abstract class ResourceBuilding: Building, IUpgradable, ISubject,IPrint
    {

        public int MaxLevel { get; set; }
        public Cost DestructionReturn { get; set; }
        public int Gain { get; set; }
        public IFarm Farm { get; set; }
        public IResourcable Warehouse { get; set; }
        public List<IObserver> Observers { get; set; }
        public Dictionary<int, Cost> ProductionCostsPerLevel { get; set; }

        
        //To Test
        public List<IResourcable> EssentialResources { get; set; }

        public ResourceBuilding(IFarm farm, IWarehouse warehouse)
        {
            CurrentLevel = 1;
            Warehouse = warehouse;
            Farm = farm;
            Observers = new List<IObserver>();


            EssentialResources = new List<IResourcable>();


            //To test
            EssentialResources.Add(farm);
            EssentialResources.Add(warehouse);


        }


        public abstract Cost GetLevelCost(int level);
       

        public void Downgrade()
        {
            throw new NotImplementedException();
        }

        public void Upgrade(IConstructionList buildList)
        {
            


            Boolean enoughResources = true; 
            foreach(IResourcable resource in EssentialResources)
            {
                if (resource.CheckEnoughResources(GetLevelCost(CurrentLevel + 1)) == false) {
                    enoughResources = false;
                    break;
                }
            }

            if (enoughResources)
            {
                ConstructionItem bi = new ConstructionItem(GetLevelCost(CurrentLevel +1), WhenUpgradeIsComplete);
                //And add it to the given list
                buildList.AddItem(bi);
            }

            foreach (IResourcable resource in EssentialResources)
            {
                resource.WithdrawResources(GetLevelCost(CurrentLevel + 1));
            }


        }


        public virtual void WhenUpgradeIsComplete(Object source, ElapsedEventArgs e)
        {
            //return villagers
            Farm.PopulationInFarm += GetLevelCost(CurrentLevel + 1 ).VillagerCost;
            CurrentLevel++;
            Gain++;
        }

    
    
        //Observers
        public void Attach(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void Notify()
        {
            foreach (IObserver observer in Observers)
            {
                observer.Update(this);
            }
        }

        public void UnAttach(IObserver observer)
        {
            throw new NotImplementedException();
        }


        //<IPrint>
        public void Print()
        {
            Console.WriteLine("Level: {0}", CurrentLevel);
            Console.Write("Upgrade Cost -> ");
            GetLevelCost(CurrentLevel+ 1).Print();
        }
    }


}

