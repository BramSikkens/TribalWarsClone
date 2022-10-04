using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TribalWarsClone.Models.Buildings
{
    internal class Farm : Building, IUpgradable
    {
        public int MaxLevel { get; }
        public int PopulationCount { get; set; }
        public ProductionCost ProductionCost { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ProductionCost DestructionReturn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Farm()
        {
            CurrentLevel = 1;
            MaxLevel = 20; 
            PopulationCount = 240;
        }

        public void downgrade()
        {
            throw new NotImplementedException();
        }

        public void upgrade()
        {
            throw new NotImplementedException();
        }

        public void upgrade(BuildList buildList)
        {
            throw new NotImplementedException();
        }
    }
}
