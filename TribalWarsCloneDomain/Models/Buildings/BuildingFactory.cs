using System;
using System.Collections.Generic;
using System.Text;
using TribalWarsCloneDomain.Models.Buildings;
using TribalWarsCloneDomain.Models;
using TribalWarsCloneDomain.Interfaces;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public class ConcreteBuildingFactory : IBuildingFactory
    {


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
            return new Farm(initialCost);
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
            return new Warehouse();
        }

        public IHeadQuarters CreateHeadQuarters()
        {
            return new HeadQuarters();
        }


    }
}
