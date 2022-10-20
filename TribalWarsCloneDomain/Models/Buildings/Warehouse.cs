
using System;
using System.Timers;
using TribalWarsCloneDomain.utils;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public class Warehouse:Building,IUpgradable,IObserver
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


        public Farm Farm { get; set; }
        Warehouse IUpgradable.Warehouse { get; set; }

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

        public void updateResources()
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

  

        public void downgrade()
        {
            throw new NotImplementedException();
        } 

        public void withdrawResources(int clayAmount=0, int ironAmount=0, int woodAmount=0)
        {
            ClayCount = ClayCount - clayAmount;
            WoodCount = WoodCount - woodAmount;
            IronCount = IronCount - ironAmount;
        }

        public void printBuildingInfo()
        {
            updateResources();
            Console.WriteLine("Iron: {0} | Wood: {1} | Clay: {2}",IronCount,WoodCount,ClayCount);
         
        }

        public void upgrade(ConstructionList buildList,Warehouse warehouse, Farm farm)
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

        public Boolean checkEnoughResources(Cost cost)
        {
            updateResources();
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

        public void onUpgradeComplete(object source, ElapsedEventArgs e)
        {
            CurrentLevel++;
            Capacity += 100;
            Console.WriteLine("Warehouse Upgraded");
       
        }

        public void upgrade(ConstructionList buildList)
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
    }
}
