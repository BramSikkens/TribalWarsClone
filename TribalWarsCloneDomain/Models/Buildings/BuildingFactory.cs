using System;
using System.Collections.Generic;
using System.Text;
using TribalWarsCloneDomain.Models.Buildings;
using TribalWarsCloneDomain.Models;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public abstract class BuildingFactory
    {
        public abstract Farm CreateFarm();
        public abstract Warehouse CreateWarehouse();

        public abstract RallyPoint CreateRallyPoint();
    }
}

public class ConcreteBuildingFactory : BuildingFactory
{


    public override Farm CreateFarm()
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

    public override RallyPoint CreateRallyPoint()
    {
        return new RallyPoint();
    }

    public override Warehouse CreateWarehouse()
    {
        return new Warehouse();
    }
}
