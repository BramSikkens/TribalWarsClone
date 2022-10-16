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
        public ConstructionList BuildList { get; set; }
        public IronFactory IronFactory { get; set; }
        public WoodFactory WoodFactory { get; set; }
        public ClayFactory ClayFactory { get; set; }
        public Smithy Smithy { get; set; }
        public Farm Farm { get; set; }
        public RallyPoint RallyPoint { get; set; }
     

        public Village(string name)
        {
            currentLevel = 0;
            Name = name;

            Farm = new Farm(new Cost
            {
                ClayCost = 1,
                IronCost = 1,
                WoodCost = 1,
                VillagerCost = 10,
                ProductionTime = 100000
            });

            BuildList = new ConstructionList(Farm);
            IronFactory = new IronFactory(new Cost
            {
                ClayCost = 1,
                IronCost =1,
                WoodCost = 1,
                VillagerCost = 10,
                ProductionTime =100000
            },20,Farm,Warehouse);
            WoodFactory = new WoodFactory(new Cost
            {
                ClayCost = 1,
                IronCost = 1,
                WoodCost = 1,
                VillagerCost = 10,
                ProductionTime = 100000
            }, 20, Farm, Warehouse);

            ClayFactory = new ClayFactory(new Cost
            {
                ClayCost = 1,
                IronCost = 1,
                WoodCost = 1,
                VillagerCost = 10,
                ProductionTime = 100000
            }, 20, Farm, Warehouse);

            Warehouse = new Warehouse(ClayFactory,IronFactory,WoodFactory);
            RallyPoint = new RallyPoint();
            Smithy = new Smithy(new Cost
            {
                ClayCost = 1,
                IronCost = 1,
                WoodCost = 1,
                VillagerCost = 10,
                ProductionTime = 100000
            },RallyPoint,Farm,Warehouse) ;

            
          
        }

        public void printBuildings()
        {
            Console.WriteLine("------ClayFactory------");
            ClayFactory.printBuildingInfo();
            Console.WriteLine();
            Console.WriteLine("------WoodFactory------");
            WoodFactory.printBuildingInfo();
            Console.WriteLine();
            Console.WriteLine("------IronFactory------");
            IronFactory.printBuildingInfo();
            Console.WriteLine();
        }

        public void showInfo()
        {
            Console.WriteLine("VillageName:{0}", Name);
        }

    }

    
}
