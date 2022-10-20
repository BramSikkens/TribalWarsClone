﻿using System;
using System.Collections.Generic;
using System.Text;
using TribalWarsCloneDomain.Models.Soldiers;
using TribalWarsCloneDomain.utils;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public class RallyPoint : Building,IObserverSmitthy
    {

        public Dictionary<String, int> SoldierAmounts { get; set; }


        public RallyPoint()
        {
            CurrentLevel = 1;
            SoldierAmounts = new Dictionary<String, int>();
            SoldierAmounts.Add(nameof(SpearSoldier), 0);

        }


        public void AddSoldierToRallyPoint(string type, int amount)
        {
            SoldierAmounts[type] += amount; 
        }

        public void printBuildingInfo()
        {
            foreach(var item in SoldierAmounts)
            {
                Console.WriteLine("{0}:{1}", item.Key, item.Value);
            }
        }

        public void Update(ISubject subject)
        {
            if(subject is Smithy)
            {

            }
        }

        public void UpdateRallyPoin(string type, int amount)
        {
           AddSoldierToRallyPoint(type, amount);
        }
    }
}
