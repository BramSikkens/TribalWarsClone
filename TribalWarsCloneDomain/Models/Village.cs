using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TribalWarsCloneDomain.Models.Buildings;

namespace TribalWarsCloneDomain.Models
{
    public class Village
    {

        public long Id { get; set; }
        public String Name { get; set; }
        public int currentLevel { get; set; }
        public Coordinates Location { get; set; }
        public Warehouse Warehouse { get; set; }
        public BuildList BuildList { get; set; }
        public IronFactory IronFactory { get; set; }
        public WoodFactory WoodFactory { get; set; }
        public ClayFactory ClayFactory { get; set; }

        public IDictionary<String,Building> Buildings { get; set; }

        public Village()
        {
            Warehouse = new Warehouse();
            BuildList = new BuildList();


            IronFactory = new IronFactory(new Cost
            {
                ClayCost = 1,
                IronCost =1,
                WoodCost = 1,
                ProductionTime =1000
            },20);
            WoodFactory = new WoodFactory(new Cost
            {
                ClayCost = 1,
                IronCost = 1,
                WoodCost = 1,
                ProductionTime = 1000
            }, 20);

            ClayFactory = new ClayFactory(new Cost
            {
                ClayCost = 1,
                IronCost = 1,
                WoodCost = 1,
                ProductionTime = 1000
            }, 20);
       
            
            //HeadQuarters hq = new HeadQuarters();

            //Buildings.Add(nameof(HeadQuarters), hq);
            //Buildings.Add(nameof(Farm), new Farm());
            //Buildings.Add(nameof(ClayFactory), new ClayFactory());
            //Buildings.Add(nameof(WoodFactory), new WoodFactory());
            //Buildings.Add(nameof(IronFactory), new IronFactory());
        }

        public void printBuildings()
        {
            Console.WriteLine("------ClayFactory------");
            ClayFactory.printStats();
            Console.WriteLine("------WoodFactory------");
            WoodFactory.printStats();
            Console.WriteLine("------IronFactory------");
            IronFactory.printStats();
        }
    }

    
}
