using System;
using System.Collections.Generic;
using System.Timers;
using TribalWarsCloneDomain.utils;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public abstract class ResourceBuilding: Building, IUpgradable, ISubject
    {

        public int MaxLevel { get; set; }
        public Cost ProductionCost { get; set; }
        public Cost DestructionReturn { get; set; }
        public int Gain { get; set; }
        public Farm Farm { get; set; }
        public Warehouse Warehouse { get; set; }
        public List<IObserver> Observers { get; set; }

        public ResourceBuilding(Cost initialCost, int maxLevel, Farm farm, Warehouse warehouse)
        {
            CurrentLevel = 1;
            MaxLevel = maxLevel;
            ProductionCost = initialCost;
            Warehouse = warehouse;
            Farm = farm;
            Observers = new List<IObserver>();

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


        public virtual void onUpgradeComplete(Object source, ElapsedEventArgs e)
        {
            CurrentLevel++;
            Gain++;

            //return villagers
            Farm.PopulationInFarm += ProductionCost.VillagerCost;
            DestructionReturn = ProductionCost;

            ProductionCost.ClayCost = (int)Math.Round(ProductionCost.ClayCost * 1.5);
            ProductionCost.IronCost = (int)Math.Round(ProductionCost.IronCost * 1.5);
            ProductionCost.WoodCost = (int)Math.Round(ProductionCost.WoodCost * 1.5);
            ProductionCost.ProductionTime = (int)Math.Round(ProductionCost.ProductionTime * 1.5);

        }

        public void printBuildingInfo()
        {
            Console.WriteLine("Level: {0}", CurrentLevel);
            Console.WriteLine("Upgrade Cost -> Iron:{0} | Wood:{1} | Clay:{2}", ProductionCost.IronCost, ProductionCost.WoodCost, ProductionCost.ClayCost);
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


    }



}

