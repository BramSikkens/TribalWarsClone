using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TribalWarsCloneDomain.Interfaces;
using TribalWarsCloneDomain.Models.Buildings;
using TribalWarsCloneDomain.Models.Buildings.Resources;
using TribalWarsCloneDomain.utils;

namespace TribalWarsCloneDomain.Models
{
    public interface IVillage:IPrint
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public int currentLevel { get; set; }
        public Coordinates Location { get; set; }

        public IConstructionList BuildList { get; set; }

        public ResourceFactory ResourceBuildingFactory { get; set; }
        public ResourceBuilding IronMine { get; set; }
        public ResourceBuilding TimberCamp { get; set; }
        public ResourceBuilding ClayPit { get; set; }

        public IBuildingFactory BuildingFactory { get; set; }
        public IWarehouse Warehouse { get; set; }
        public IFarm Farm { get; set; }


        public ISmithy Smithy { get; set; }
        public IRallyPoint RallyPoint { get; set; }

    
    }

    public class Village:IVillage
    {

        public long Id { get; set; }
        public String Name { get; set; }
        public int currentLevel { get; set; }
        public Coordinates Location { get; set; }

        public IConstructionList BuildList { get; set; }


        public ResourceFactory ResourceBuildingFactory { get; set; }
        public ResourceBuilding IronMine { get; set; }
        public ResourceBuilding TimberCamp { get; set; }
        public ResourceBuilding ClayPit { get; set; }

        public IBuildingFactory BuildingFactory { get; set; }
        public IWarehouse Warehouse { get; set; }
        public IFarm Farm { get; set; }


        public ISmithy Smithy { get; set; }
        public IRallyPoint RallyPoint { get; set; }

        //Testing
       

        public Village(string name)
        {
            currentLevel = 0;
            Name = name;

            BuildingFactory = new ConcreteBuildingFactory();


            Warehouse = BuildingFactory.CreateWarehouse();
            Farm = BuildingFactory.CreateFarm();
            RallyPoint = BuildingFactory.CreateRallyPoint();


            ResourceBuildingFactory = new ConcreteResourceFactory(Warehouse, Farm);

            BuildList = new ConstructionList((Farm)Farm);
            IronMine = ResourceBuildingFactory.CreateIronMine();
            TimberCamp = ResourceBuildingFactory.CreateTimberCamp();
            ClayPit = ResourceBuildingFactory.CreateClayPit();




            Smithy = ResourceBuildingFactory.CreateSmithy();
            Smithy.Attach(RallyPoint);




        }

        private void printBuildings()
        {
            Console.WriteLine("------ClayPit------");
            ClayPit.Print();
            Console.WriteLine();
            Console.WriteLine("------TimberCamp------");
            TimberCamp.Print();
            Console.WriteLine();
            Console.WriteLine("------IronMine------");
            IronMine.Print();
            Console.WriteLine();
        }

        private void showInfo()
        {
            Console.WriteLine("VillageName:{0}", Name);
        }

        public void Print()
        {
            showInfo();
        }
    }

    
}
