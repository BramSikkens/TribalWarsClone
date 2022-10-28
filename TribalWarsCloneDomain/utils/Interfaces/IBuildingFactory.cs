using System;
using TribalWarsCloneDomain.Models.Buildings;

namespace TribalWarsCloneDomain.Interfaces
{
    public interface IBuildingFactory
    {
        public IHeadQuarters CreateHeadQuarters();

        public ClayPit CreateClayPit(IFarm farm, IWarehouse warehouse);
        public TimberCamp CreateTimberCamp(IFarm farm, IWarehouse warehouse);
        public IronMine CreateIronMine(IFarm farm, IWarehouse warehouse);
        public Smithy CreateSmithy(IFarm farm, IWarehouse warehouse);

        public IFarm CreateFarm();
        public IWarehouse CreateWarehouse();
        public IRallyPoint CreateRallyPoint();
        public Wall CreateWall();
    }
}

