using System;
using System.Collections.Generic;
using System.Text;
using TribalWarsCloneDomain.Models.Buildings;
using TribalWarsCloneDomain.Models.Soldiers;

namespace TribalWarsCloneDomain.Models
{
    public interface IArmyCreator
    {
  
        public Dictionary<string, Soldier> Soldiers { get; set; }
        public Boolean isSoldierDeveloped(string type);
        public void developSoldier(string type);
        public void TrainSoldier(string type, int amount);


    }
}
