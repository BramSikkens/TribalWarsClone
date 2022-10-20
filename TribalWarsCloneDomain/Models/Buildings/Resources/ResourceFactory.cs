using System;
using System.Collections.Generic;
using System.Text;
using TribalWarsCloneDomain.Models.Buildings;
using TribalWarsCloneDomain.Models;
using TribalWarsCloneDomain.Models.Buildings.Resources;
using TribalWarsCloneDomain.utils;

namespace TribalWarsCloneDomain.Models.Buildings.Resources
{

    public abstract class ResourceFactory
    {

        public Warehouse Warehouse {get;set;}
        public Farm Farm { get; set; }
        

        public abstract ClayPit CreateClayPit();
        public abstract IronMine CreateIronMine();
        public abstract TimberCamp CreateTimberCamp();

        public abstract Smithy CreateSmithy();
        

        public  ResourceFactory(Warehouse warehouse, Farm farm)
        {
            this.Warehouse = warehouse;
            this.Farm = farm;   
        }
    }

    public class ConcreteResourceFactory : ResourceFactory
    {

        public ConcreteResourceFactory(Warehouse warehouse, Farm farm):base(warehouse,farm)
        {

        }

        public override ClayPit CreateClayPit()
        {
            Cost initialCost = (new Cost
            {
                ClayCost = 1,
                IronCost = 1,
                WoodCost = 1,
                VillagerCost = 10,
                ProductionTime = 100000
            });
            int maxLevel = 20;

            ClayPit newClayPit = new ClayPit(initialCost, maxLevel, Farm, Warehouse);
            if (newClayPit is ISubject)
            {
                (newClayPit as ISubject).Attach(Warehouse);
            }
            return newClayPit;
        }

        public override IronMine CreateIronMine()
        {
            Cost initialCost = (new Cost
            {
                ClayCost = 1,
                IronCost = 1,
                WoodCost = 1,
                VillagerCost = 10,
                ProductionTime = 100000
            });
            int maxLevel = 20;
            IronMine newIronMine = new IronMine(initialCost, maxLevel, Farm, Warehouse);

            if(newIronMine is ISubject)
            {
                (newIronMine as ISubject).Attach(Warehouse); 
            }

            return newIronMine;
        }

        public override Smithy CreateSmithy()
        {
            Cost initialCost = (new Cost
            {
                ClayCost = 1,
                IronCost = 1,
                WoodCost = 1,
                VillagerCost = 10,
                ProductionTime = 100000
            });
            int maxLevel = 20;
            Smithy newSmithy = new Smithy(initialCost, Farm, Warehouse);

          

            return newSmithy;
        }

        public override TimberCamp CreateTimberCamp()
        {
            Cost initialCost = (new Cost
            {
                ClayCost = 1,
                IronCost = 1,
                WoodCost = 1,
                VillagerCost = 10,
                ProductionTime = 100000
            });
            int maxLevel = 20;

            TimberCamp newTimberCamp = new TimberCamp(initialCost, maxLevel, Farm, Warehouse);

            if (newTimberCamp is ISubject)
            {
                (newTimberCamp as ISubject).Attach(Warehouse);
            }

            return newTimberCamp;

      
        }
    }


}


