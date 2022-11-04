﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TribalWarsCloneDomain.Interfaces;
using TribalWarsCloneDomain.Models.Buildings;
using TribalWarsCloneDomain.utils;
using TribalWarsCloneDomain.utils.Interfaces;

namespace TribalWarsCloneDomain.Models
{
    public interface IVillage:IPrint
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public int currentLevel { get; set; }
        public Coordinates Location { get; set; }

        public IConstructionList BuildList { get; set; }


        public ResourceBuilding IronMine { get; set; }
        public ResourceBuilding TimberCamp { get; set; }
        public ResourceBuilding ClayPit { get; set; }



        public IWarehouse Warehouse { get; set; }
        public IFarm Farm { get; set; }


        public ISmithy Smithy { get; set; }
        public IRallyPoint RallyPoint { get; set; }

        public Dictionary<string,Requirement> BuildingRequirements { get; set; }

        public void AddSmithy();




    }

    public class Village:IVillage
    {

        public long Id { get; set; }
        public String Name { get; set; }
        public int currentLevel { get; set; }
        public Coordinates Location { get; set; }

        public IConstructionList BuildList { get; set; }


        public ResourceBuilding IronMine { get; set; }
        public ResourceBuilding TimberCamp { get; set; }
        public ResourceBuilding ClayPit { get; set; }

        public IBuildingFactory BuildingFactory { get; set; }
        public IWarehouse Warehouse { get; set; }
        public IFarm Farm { get; set; }


        public Dictionary<string, Requirement> BuildingRequirements { get; set; }



        public ISmithy Smithy { get; set; }
        public IRallyPoint RallyPoint { get; set; }

        //Testing


        public Village(string name)
        {
            currentLevel = 0;
            Name = name;
            //Smithy.Attach(RallyPoint);

            BuildingRequirements = new Dictionary<string, Requirement>();
            BuildingRequirements.Add(nameof(Smithy), new Requirement()
            {
                BuildingRequirement = "IronMine",
                PropertyRequirement = "CurrentLevel",
                ValueRequirement = "3"

            });

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

        public void AddSmithy()
        {
            var objectRequirement = this.GetType().GetProperty(BuildingRequirements[nameof(Smithy)].BuildingRequirement).GetValue(this, null);
            var objectPropertyRequirement = objectRequirement.GetType().GetProperty(BuildingRequirements[nameof(Smithy)].PropertyRequirement).GetValue(BuildingRequirements[nameof(Smithy)].ValueRequirement, null);



            if (IronMine.CurrentLevel == 2)
            {
                Console.WriteLine("Iron Mine should be level 2"); return;
            }
            if(this.Smithy == null)
            {
                this.Smithy = new ConcreteBuildingFactory().CreateSmithy(this.Farm,this.Warehouse); 
            }
        }

        public void Print()
        {
            showInfo();
        }
    }

    
}
