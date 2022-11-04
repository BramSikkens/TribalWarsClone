using System;
using System.Collections.Generic;
using System.Text;

namespace TribalWarsCloneDomain.Models.Soldiers
{
    public class SoldierStats
    {
        public int Speed { get; set; }
        public int Capacity { get; set; }

        public int AttackingPower { get; set; }
        public int GeneralDefence { get; set; }
        public int CavalaryDefence { get; set; }
        public int ArcheryDefence { get; set; }
    }
}
