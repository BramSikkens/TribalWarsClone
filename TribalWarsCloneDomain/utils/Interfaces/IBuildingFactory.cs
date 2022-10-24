using System;
using TribalWarsCloneDomain.Models.Buildings;

namespace TribalWarsCloneDomain.Interfaces
{
    public interface IBuildingFactory
    {
        public IHeadQuarters CreateHeadQuarters();
        public IFarm CreateFarm();
        public IWarehouse CreateWarehouse();
        public IRallyPoint CreateRallyPoint();
        public Wall CreateWall();
    }
}

