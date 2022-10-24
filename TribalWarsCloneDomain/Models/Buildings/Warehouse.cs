
using System;
using System.Timers;
using TribalWarsCloneDomain.Interfaces;
using TribalWarsCloneDomain.utils;
using TribalWarsCloneDomain.utils.Interfaces;

namespace TribalWarsCloneDomain.Models.Buildings
{


    public interface IWarehouse : IUpgradable, IObserver,IPrint, IResourceble
    {
        public DateTime LastUpdated { get; set; }
        public int IronGain { get; set; }
        public int WoodGain { get; set; }
        public int ClayGain { get; set; }

        public int IronLevel { get; set; }
        public int WoodLevel { get; set; }
        public int ClayLevel { get; set; }



    }

    public class Warehouse:Building,IWarehouse
    {
        public int MaxLevel { get; }
        public int ClayCount { get; set; }
        public int WoodCount { get; set; }
        public int IronCount { get; set; }
        public int Capacity { get; set; }
        public Cost ProductionCost { get; set; }
        public Cost DestructionReturn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //testing
        public DateTime LastUpdated { get; set; }
        public int IronGain { get; set; }
        public int WoodGain { get; set; }
        public int ClayGain { get; set; }

        public int IronLevel { get; set; }
        public int WoodLevel { get; set; }
        public int ClayLevel { get; set; }


        public IFarm Farm { get; set; }
       // IWarehouse IUpgradable.Warehouse { get; set; }

        public Warehouse()
        {
            CurrentLevel = 1;
            MaxLevel = 20;
            Capacity = 10;

            //testing
            LastUpdated = DateTime.Now;
            ClayCount = 1000;
            IronCount = 1000;
            WoodCount = 1000;

            ProductionCost = new Cost
            {
                ClayCost = 2,
                IronCost = 2,
                WoodCost = 2,
                ProductionTime = 1000

            };

        }

        public void UpdateResources()
        {
            var deltaTime = (DateTime.Now - LastUpdated).Seconds;

            int ironAddition = IronGain * IronLevel * deltaTime;
            int woodAddition = WoodGain * WoodLevel * deltaTime;
            int clayAddition = ClayGain * ClayLevel * deltaTime;

            if(IronCount + ironAddition > Capacity)
            {
                IronCount = Capacity;
                Console.WriteLine("Iron is full");

            }
            else
            {
                IronCount += ironAddition;
            }

            if (WoodCount + woodAddition > Capacity)
            {
                WoodCount = Capacity;
                Console.WriteLine("Wood is full");

            }
            else
            {
                WoodCount += woodAddition;

            }



            if (ClayCount + clayAddition > Capacity)
            {
                ClayCount = Capacity;
                Console.WriteLine("Clay is full");
            }
            else
            {
                ClayCount += clayAddition;
            }
            LastUpdated = DateTime.Now;
        }

  

        public void Downgrade()
        {
            throw new NotImplementedException();
        } 

        public void WithdrawResources(Cost cost)
        {
            ClayCount = ClayCount - cost.ClayCost;
            WoodCount = WoodCount - cost.WoodCost;
            IronCount = IronCount - cost.IronCost;
        }


        public void Upgrade(IConstructionList buildList,IWarehouse warehouse, IFarm farm)
        {
            //First we check if there is enough in the warehouse
            if (warehouse.CheckEnoughResources(ProductionCost))
            {
                //We create a buildTask(ITem) 
                ConstructionItem bi = new ConstructionItem(this.ProductionCost, WhenUpgradeIsComplete);
                //And add it to the given list
                buildList.AddItem(bi);
                //Remove cost from Warehouse
                warehouse.WithdrawResources(ProductionCost);
            }
            else
            {
                Console.WriteLine("Not enough Resources");
            }
        }

        public Boolean CheckEnoughResources(Cost cost)
        {
            UpdateResources();
            if(cost.ClayCost > ClayCount)
            {
                return false;
            }
            if(cost.IronCost > IronCount)
            {
                return false; 
            }
            if(cost.WoodCost > WoodCount)
            {
                return false;
            }
            return true;
        }

        public void WhenUpgradeIsComplete(object source, ElapsedEventArgs e)
        {
            CurrentLevel++;
            Capacity += 100;
            Console.WriteLine("Warehouse Upgraded");
       
        }

        public void Upgrade(IConstructionList buildList)
        {
            throw new NotImplementedException();
        }

        public void Update(ISubject subject)
        {

            //When a resourceFactory is upgraded, update my data; 
            if(subject is IronMine)
            {
                IronLevel = (subject as IronMine).CurrentLevel;
                IronGain = (subject as IronMine).Gain; 
            }
            if (subject is TimberCamp)
            {
                WoodLevel = (subject as TimberCamp).CurrentLevel;
                WoodGain = (subject as TimberCamp).Gain;
            }
            if (subject is ClayPit)
            {
                ClayLevel = (subject as ClayPit).CurrentLevel;
                ClayGain = (subject as ClayPit).Gain;
            }
        }

        public void Print()
        {
            UpdateResources();
            Console.WriteLine("Iron: {0} | Wood: {1} | Clay: {2}", IronCount, WoodCount, ClayCount);

        }
    }
}
