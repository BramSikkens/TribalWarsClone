using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TribalWarsCloneDomain.Interfaces;
using TribalWarsCloneDomain.Models.Buildings;
using TribalWarsCloneDomain.utils;
using TribalWarsCloneDomain.utils.Interfaces;
using TribalWarsCloneDomain.utils.JSONWorldSettings;

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





        public ISmithy Smithy { get; set; }
        public IRallyPoint RallyPoint { get; set; }

        //Testing


        public Village(string name)
        {
            currentLevel = 0;
            Name = name;
            BuildingFactory = new ConcreteBuildingFactory(); 
        }


   

      
        //Dit moet beter
        public void AddSmithy()
        {
            //Get The Object Requirement
            var objectRequirement = this.GetType().GetProperty(WorldSettings.SmithyRequirement.BuildingRequirement).GetValue(this,null);
            //Get The property Requiremnt and its value
            var objectPropertyRequirement = objectRequirement.GetType().GetProperty(WorldSettings.SmithyRequirement.PropertyRequirement).GetValue(objectRequirement,null);

            //check if the value of the property is == to the requirement
            if (objectPropertyRequirement.ToString() == WorldSettings.SmithyRequirement.ValueRequirement )
            {
                
                ConstructionItem ci = new ConstructionItem(WorldSettings.SmithyProductionCosts["1"], (object source, ElapsedEventArgs e) =>{ this.Smithy = this.BuildingFactory.CreateSmithy(this.Farm, this.Warehouse);  this.Smithy.Attach(RallyPoint);});
                    this.BuildList.AddItem(ci);
              
            }
            else
            {
                Console.WriteLine("{0} should have {1}:{2}", WorldSettings.SmithyRequirement.BuildingRequirement, WorldSettings.SmithyRequirement.PropertyRequirement, WorldSettings.SmithyRequirement.ValueRequirement);
            }
            
        }

        


        public void Print()
        {
            Console.WriteLine("VillageName:{0}", Name);
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
    }

    
}
