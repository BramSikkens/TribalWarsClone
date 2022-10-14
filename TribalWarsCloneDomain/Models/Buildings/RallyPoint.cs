using System;
using System.Collections.Generic;
using System.Text;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public class RallyPoint:Building
    {

        public int SpearSoldierAmount { get; set; }


        public RallyPoint()
        {
            CurrentLevel = 1;
            SpearSoldierAmount = 0;
        }

        public void printInfo()
        {
            Console.WriteLine("SpearAmount:{0}", SpearSoldierAmount);
        }
    }
}
