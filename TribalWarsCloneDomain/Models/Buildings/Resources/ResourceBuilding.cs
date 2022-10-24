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
        public Cost ProductionCost { get; set; }
        public Cost DestructionReturn { get; set; }
        public int Gain { get; set; }
        public IFarm Farm { get; set; }
        public IResourceble Warehouse { get; set; }
        public List<IObserver> Observers { get; set; }

        public ResourceBuilding(Cost initialCost, int maxLevel, IFarm farm, IWarehouse warehouse)
        {
            CurrentLevel = 1;
            MaxLevel = maxLevel;
            ProductionCost = initialCost;
            Warehouse = warehouse;
            Farm = farm;
            Observers = new List<IObserver>();

        }


        public void Downgrade()
        {
            throw new NotImplementedException();
        }

        public void Upgrade(IConstructionList buildList)
        {
            Boolean enoughResources = Warehouse.CheckEnoughResources(ProductionCost);
            Boolean enoughVillagers = Farm.CheckEnoughResources(ProductionCost);

            //First we check if there is enough in the warehouse
            if (enoughResources && enoughVillagers)
            {
                //We create a buildTask(ITem) 
                ConstructionItem bi = new ConstructionItem(this.ProductionCost, WhenUpgradeIsComplete);
                //And add it to the given list
                buildList.AddItem(bi);
                //Remove cost from Warehouse
                Warehouse.WithdrawResources(ProductionCost);
                Farm.WithdrawResources(ProductionCost);

            }
            else
            {
                Console.WriteLine("Not enough Resources");
            }
        }


        public virtual void WhenUpgradeIsComplete(Object source, ElapsedEventArgs e)
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

        public void Print()
        {
            Console.WriteLine("Level: {0}", CurrentLevel);
            Console.WriteLine("Upgrade Cost -> Iron:{0} | Wood:{1} | Clay:{2}", ProductionCost.IronCost, ProductionCost.WoodCost, ProductionCost.ClayCost);
        }
    }



}

