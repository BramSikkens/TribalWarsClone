  using System;
using System.Collections.Generic;
using System.Text;
using TribalWarsCloneDomain.Interfaces;
using TribalWarsCloneDomain.Models;
using TribalWarsCloneDomain.Models.Buildings;

namespace TribalWarsCloneDomain.utils.JSONWorldSettings
{
    public class VillageBuilder
    {
       private Village Village { get;set; }
       private IBuildingFactory BuildingFactory { get; set; }

       

        public VillageBuilder()
        {
        }

        private void InitVillage(string name)
        {
            Village = new Village(name);
        }

        private void GenerateBuildingFactory()
        {
            BuildingFactory = new ConcreteBuildingFactory();
        }

        private void GenerateWarehouse()
        {
            Village.Warehouse = BuildingFactory.CreateWarehouse(); 
        }

        private void GenerateFarm()
        {
            Village.Farm = BuildingFactory.CreateFarm();
        }

        private void GenerateRallyPoint()
        {
            Village.RallyPoint = BuildingFactory.CreateRallyPoint();
        }

        private void GenerateResourceFactory()
        {
           // ResourceFactory = new ConcreteResourceFactory(Village.Warehouse,Village.Farm); 
        }

        private void GenerateIronMine()
        {
            Village.IronMine = BuildingFactory.CreateIronMine(Village.Farm,Village.Warehouse);
        }

         private void GenerateTimberCamp()
        {
            Village.TimberCamp = BuildingFactory.CreateTimberCamp(Village.Farm, Village.Warehouse);
        }

        private void GenerateClayPit()
        {
            Village.ClayPit = BuildingFactory.CreateClayPit(Village.Farm, Village.Warehouse);
        }

        private void GenerateSmithy()
        {

            //Testing
            Village.Smithy = BuildingFactory.CreateSmithy(Village.Farm, Village.Warehouse);
            Village.Smithy.Attach(Village.RallyPoint);
        }

        private Village getVillage()
        {
            return this.Village;
        }

        private void GenerateBuildList()
        {
            Village.BuildList = new ConstructionList(Village.Farm);
        }
       
        public Village CreateVillage(string name)
        {
            InitVillage(name);
            GenerateBuildingFactory();
            GenerateWarehouse();
            GenerateFarm();
            GenerateBuildList();
            GenerateRallyPoint();
            GenerateResourceFactory();
            GenerateIronMine();
            GenerateTimberCamp();
            GenerateClayPit();
           // GenerateSmithy();
            return getVillage();
        }
    }
}
