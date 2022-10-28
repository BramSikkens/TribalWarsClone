using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TribalWarsCloneDomain.Models
{
    public class Cost:IPrint
    {
        public int WoodCost { get; set; }
        public int IronCost { get; set; }
        public int ClayCost { get; set; }
        public int ProductionTime { get; set; }
        public int VillagerCost { get; set; }

        public void Print()
        {
            Console.WriteLine("WoodCost:{0} | IronCost:{1} | ClayCost:{2} | ProductionTime:{3} | VillagerCost:{4}", WoodCost, IronCost, ClayCost, ProductionTime, VillagerCost);
        }
    }
}
