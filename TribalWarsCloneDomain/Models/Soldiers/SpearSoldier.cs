using System;
using System.Collections.Generic;
using System.Text;

namespace TribalWarsCloneDomain.Models.Soldiers
{
    public class SpearSoldier : Soldier
    {
        public SpearSoldier( Cost productionCost, int speed, int capacity, int attackPower, int generalDefence, int cavalaryDefence, int archeryDefence) : base( productionCost, speed, capacity, attackPower, generalDefence, cavalaryDefence, archeryDefence)
        {

        }

    }
}
