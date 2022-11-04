using System;
using System.Collections.Generic;
using System.Text;
using TribalWarsCloneDomain.Models.Buildings;
using TribalWarsCloneDomain.Models;
using TribalWarsCloneDomain.Interfaces;
using TribalWarsCloneDomain.utils;
using TribalWarsCloneDomain.utils.JSONWorldSettings;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public class ConcreteBuildingFactory : IBuildingFactory
    {
    

        public IFarm CreateFarm()
        {
         
            return new Farm();
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

        public ClayPit CreateClayPit(IFarm farm, IWarehouse warehouse)
        {


            ClayPit newClayPit = new ClayPit( farm, warehouse);
            if (newClayPit is ISubject)
            {
                (newClayPit as ISubject).Attach(warehouse);
            }
            return newClayPit;
        }

        public TimberCamp CreateTimberCamp(IFarm farm, IWarehouse warehouse)
        {

            TimberCamp newTimberCamp = new TimberCamp(farm, warehouse);

            if (newTimberCamp is ISubject)
            {
                (newTimberCamp as ISubject).Attach(warehouse);
            }

            return newTimberCamp;
        }

        public IronMine CreateIronMine(IFarm farm, IWarehouse warehouse)
        {
            IronMine newIronMine = new IronMine(farm, warehouse);

            if (newIronMine is ISubject)
            {
                (newIronMine as ISubject).Attach(warehouse);
            }

            return newIronMine;
        }

        public Smithy CreateSmithy(IFarm farm, IWarehouse warehouse)
        {

            
            Smithy newSmithy = new Smithy(farm, warehouse);
            return newSmithy;
        }
    }
}
