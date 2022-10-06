using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public class IronFactory :ResourceFactory, IUpgradable
    {
       
        public int IronGain { get; set; }

        public IronFactory(Cost initialCost, int maxLevel):base(initialCost,maxLevel)   
        {
            CurrentLevel = 1;
            MaxLevel = maxLevel;
            ProductionCost = initialCost;
            IronGain = 1; 
        }

        public override void onUpgradeComplete(Object source, ElapsedEventArgs e)
        {
            CurrentLevel++;
            IronGain++;
            Console.WriteLine("IronFactory Upgraded");
            ProductionCost.ClayCost = (int)Math.Round(ProductionCost.ClayCost * 1.5);
            ProductionCost.IronCost = (int)Math.Round(ProductionCost.IronCost * 1.5);
            ProductionCost.WoodCost = (int)Math.Round(ProductionCost.WoodCost * 1.5);
            ProductionCost.ProductionTime = (int)Math.Round(ProductionCost.ProductionTime * 1.5);
        }




        
    }
}
