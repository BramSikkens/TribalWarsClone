using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TribalWarsClone.Models.Buildings
{
    internal class IronFactory : Building, IUpgradable
    {
        public int MaxLevel { get; }
        public ProductionCost ProductionCost { get; set; }
        public ProductionCost DestructionReturn { get; set; }

        public IronFactory()
        {
            CurrentLevel = 0;
            MaxLevel = 20;
            ProductionCost = new ProductionCost
            {
                ClayCost = 100,
                IronCost = 60,
                WoodCost = 120,
                ProductionTime = 500

            };
        }

        public void downgrade()
        {
            throw new NotImplementedException();
        }

        public void onUpgradeComplete(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("IronFactory Upgraded");
            CurrentLevel++;
            ProductionCost.ClayCost = (int)Math.Round(ProductionCost.ClayCost * 1.5);
            ProductionCost.IronCost = (int)Math.Round(ProductionCost.IronCost * 1.5);
            ProductionCost.WoodCost = (int)Math.Round(ProductionCost.WoodCost * 1.5);
        }

        public void upgrade(BuildList buildList)
        {

            BuildItem bi = new BuildItem(this.ProductionCost, onUpgradeComplete);
            buildList.AddItem(bi);
            
        }

        public void printStats()
        {
            Console.WriteLine("CurrentLevel:" + CurrentLevel);
            Console.WriteLine("Clay Cost Upgrade:" + ProductionCost.ClayCost);
            Console.WriteLine("Iron Cost Upgrade:" + ProductionCost.IronCost);
            Console.WriteLine("Wood Cost Upgrade:" + ProductionCost.WoodCost);
        }

        
    }
}
