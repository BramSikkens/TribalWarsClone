using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public class ClayFactory : ResourceFactory,IUpgradable
    {
        public int ClayGain { get; set; }

        public ClayFactory(Cost initialCost, int maxLevel):base(initialCost,maxLevel)
        {
            CurrentLevel = 1;
            ProductionCost = initialCost;
            MaxLevel = maxLevel;
            ClayGain = 1;
        }

        public override void onUpgradeComplete(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("IronFactory Upgraded");
            CurrentLevel++;
            ClayGain++;

            DestructionReturn = ProductionCost; 

            ProductionCost.ClayCost = (int)Math.Round(ProductionCost.ClayCost * 1.5);
            ProductionCost.IronCost = (int)Math.Round(ProductionCost.IronCost * 1.5);
            ProductionCost.WoodCost = (int)Math.Round(ProductionCost.WoodCost * 1.5);
            ProductionCost.ProductionTime = (int)Math.Round(ProductionCost.ProductionTime * 1.5);



        }

      


    }
}
