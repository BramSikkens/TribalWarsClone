using System;
using System.Collections.Generic;
using System.Text;

namespace TribalWarsCloneDomain.Models.Soldiers
{
    public abstract class Soldier
    {
        public Cost ProductionCost { get; set; }
        public int Speed { get; set; }
        public int Capacity { get; set; }

        public int AttackingPower { get; set; }
        public int GeneralDefence { get; set; }
        public int CavalaryDefence { get; set; }
        public int ArcheryDefence { get; set; }

        public Soldier(Cost productionCost,int speed,int capacity, int attackPower,int generalDefence,int cavalaryDefence,int archeryDefence)
        {
           
            ProductionCost = productionCost;
            Speed = speed;
            Capacity = capacity;
            AttackingPower = attackPower;
            GeneralDefence = generalDefence;
            CavalaryDefence = cavalaryDefence;
            ArcheryDefence = archeryDefence;
        }
    }
}
