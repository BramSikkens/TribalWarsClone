using System;
using System.Collections.Generic;
using System.Text;
using TribalWarsCloneDomain.Models.Buildings;
using TribalWarsCloneDomain.Models;
using TribalWarsCloneDomain.Interfaces;
using TribalWarsCloneDomain.utils;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public class ConcreteBuildingFactory : IBuildingFactory
    {
        private Dictionary<int, Cost> BuildingCosts = new Dictionary<int, Cost>()
        {

            { 1, new Cost(){
            WoodCost=1,
            IronCost=1,
            ClayCost=1,
            VillagerCost=1,
            ProductionTime=1000} },
               { 2, new Cost(){
            WoodCost=2,
            IronCost=2,
            ClayCost=2,
            VillagerCost=2,
            ProductionTime=2000} },
                  { 3, new Cost(){
            WoodCost=3,
            IronCost=3,
            ClayCost=3,
            VillagerCost=3,
            ProductionTime=3000} }
        };

        public IFarm CreateFarm()
        {
            Cost initialCost = (new Cost
            {
                ClayCost = 1,
                IronCost = 1,
                WoodCost = 1,
                VillagerCost = 10,
                ProductionTime = 100000
            });
            return new Farm(BuildingCosts);
        }

        public IRallyPoint CreateRallyPoint()
        {
            return new RallyPoint();
        }

        public Wall CreateWall()
        {
            return new Wall();
        }

        public IWarehouse CreateWarehouse()
        {
            return new Warehouse(BuildingCosts);
        }

        public IHeadQuarters CreateHeadQuarters()
        {
            return new HeadQuarters();
        }

        public ClayPit CreateClayPit(IFarm farm, IWarehouse warehouse)
        {

            int maxLevel = 20;

            ClayPit newClayPit = new ClayPit(BuildingCosts, maxLevel, farm, warehouse);
            if (newClayPit is ISubject)
            {
                (newClayPit as ISubject).Attach(warehouse);
            }
            return newClayPit;
        }

        public TimberCamp CreateTimberCamp(IFarm farm, IWarehouse warehouse)
        {
            int maxLevel = 20;

            TimberCamp newTimberCamp = new TimberCamp(BuildingCosts, maxLevel, farm, warehouse);

            if (newTimberCamp is ISubject)
            {
                (newTimberCamp as ISubject).Attach(warehouse);
            }

            return newTimberCamp;
        }

        public IronMine CreateIronMine(IFarm farm, IWarehouse warehouse)
        {
            int maxLevel = 20;
            IronMine newIronMine = new IronMine(BuildingCosts, maxLevel, farm, warehouse);

            if (newIronMine is ISubject)
            {
                (newIronMine as ISubject).Attach(warehouse);
            }

            return newIronMine;
        }

        public Smithy CreateSmithy(IFarm farm, IWarehouse warehouse)
        {
   
            int maxLevel = 20;
            Smithy newSmithy = new Smithy(BuildingCosts, farm, warehouse);



            return newSmithy;
        }
    }
}
