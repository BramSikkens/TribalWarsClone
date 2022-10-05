
using System;
using System.Timers;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public class Warehouse:Building,IUpgradable
    {
        public int MaxLevel { get; }
        public int ClayCount { get; set; }
        public int WoodCount { get; set; }
        public int IronCount { get; set; }
        public int Capacity { get; set; }
        public Cost ProductionCost { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Cost DestructionReturn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Warehouse()
        {
            CurrentLevel = 1;
            MaxLevel = 20;
            Capacity = 1000;
            ClayCount = 0;
            IronCount = 0;
            WoodCount = 0;


            Filler ironFiller = new Filler(1000, onIronFill);
            Filler woodFiller = new Filler(5000, onWoodFill);
            Filler clayFiller = new Filler(10000, onClayFill);


        }

        public void downgrade()
        {
            throw new NotImplementedException();
        } 

        private void onWoodFill(Object source, ElapsedEventArgs e)
        {
            WoodCount++; 
        }
        private void onIronFill(Object source, ElapsedEventArgs e)
        {
            IronCount++;
       
        }

        private void onClayFill(Object source, ElapsedEventArgs e)
        {
            ClayCount++;
        }




        public void takeOutResources(int clayAmount, int ironAmount, int woodAmount)
        {
            ClayCount = ClayCount - clayAmount;
            WoodCount = WoodCount - woodAmount;
            IronCount = IronCount - ironAmount;
        }

        public void print()
        {
            Console.WriteLine("IronCount:" + IronCount);
            Console.WriteLine("WoodCount:" + WoodCount);
            Console.WriteLine("ClayCount" + ClayCount);
        }

        public void upgrade(BuildList buildList,Warehouse warehouse)
        {
            throw new NotImplementedException();
        }

        public Boolean checkEnoughResources(Cost cost)
        {
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
    }
}
