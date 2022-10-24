using System;
namespace TribalWarsCloneDomain.Models.Soldiers
{
    public class ArcherySoldier:Soldier
    {
        public ArcherySoldier(Cost productionCost, int speed, int capacity, int attackPower, int generalDefence, int cavalaryDefence, int archeryDefence) : base(productionCost, speed, capacity, attackPower, generalDefence, cavalaryDefence, archeryDefence)
        {
        }
    }
}

