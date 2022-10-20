using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TribalWarsCloneDomain.Models.Buildings;
using TribalWarsCloneDomain.Models.Buildings.Resources;
using TribalWarsCloneDomain.utils;

namespace TribalWarsCloneDomain.Models
{
    public class Village
    {

        public long Id { get; set; }
        public String Name { get; set; }
        public int currentLevel { get; set; }
        public Coordinates Location { get; set; }

        public ConstructionList BuildList { get; set; }


        public ResourceFactory ResourceBuildingFactory { get; set; }
        public ResourceBuilding IronMine { get; set; }
        public ResourceBuilding TimberCamp { get; set; }
        public ResourceBuilding ClayPit { get; set; }

        public BuildingFactory BuildingFactory { get; set; }
        public Building Warehouse { get; set; }
        public Building Farm { get; set; }


        public Smithy Smithy { get; set; }
        public RallyPoint RallyPoint { get; set; }

        //Testing
       

        public Village(string name)
        {
            currentLevel = 0;
            Name = name;

            BuildingFactory = new ConcreteBuildingFactory();


            Warehouse = BuildingFactory.CreateWarehouse();
            Farm = BuildingFactory.CreateFarm();
            RallyPoint = BuildingFactory.CreateRallyPoint();


            ResourceBuildingFactory = new ConcreteResourceFactory((Warehouse)Warehouse, ((Farm)Farm));

            BuildList = new ConstructionList((Farm)Farm);
            IronMine = ResourceBuildingFactory.CreateIronMine();
            TimberCamp = ResourceBuildingFactory.CreateTimberCamp();
            ClayPit = ResourceBuildingFactory.CreateClayPit();




            Smithy = ResourceBuildingFactory.CreateSmithy();
            (Smithy as ISubject).Attach(RallyPoint);




        }

        public void printBuildings()
        {
            Console.WriteLine("------ClayPit------");
            ClayPit.printBuildingInfo();
            Console.WriteLine();
            Console.WriteLine("------TimberCamp------");
            TimberCamp.printBuildingInfo();
            Console.WriteLine();
            Console.WriteLine("------IronMine------");
            IronMine.printBuildingInfo();
            Console.WriteLine();
        }

        public void showInfo()
        {
            Console.WriteLine("VillageName:{0}", Name);
        }

    }

    
}
