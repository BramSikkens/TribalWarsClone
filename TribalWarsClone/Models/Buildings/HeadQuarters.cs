using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TribalWarsClone.Models.Buildings
{
    internal class HeadQuarters : Building, IUpgradable
    {
        public int MaxLevel { get; set; }
        public ProductionCost ProductionCost { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ProductionCost DestructionReturn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public HeadQuarters()
        {
            CurrentLevel = 1;
            MaxLevel = 20;
        }

        public void downgrade()
        {
            throw new NotImplementedException();
        }

        public void upgrade()
        {
         
          
        }

        public void upgrade(BuildList buildList)
        {
            throw new NotImplementedException();
        }
    }
}
