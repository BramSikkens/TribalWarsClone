using System;
using System.Collections.Generic;
using System.Text;

namespace TribalWarsCloneDomain.utils.JSONWorldSettings
{
    public class upgradeCost
    {  
        public int woodCost { get; set; }
        public int ironCost { get; set; }
        public int clayCost { get; set; }
        public int productionTime { get; set; }
        public int villagerCost { get; set; }

    }

    public class BuildingDTO
    {
        public string name { get; set; }
        public bool prebuild { get; set; }
        public int startLevel { get; set; }
        public int maxLevel { get; set; }
        public Dictionary<string,upgradeCost> upgradeCosts { get; set; }
        public Dictionary<string,int> levelPoints { get; set; }
    }

    public class WorldDTO
    {
        public string name { get; set; }
        public List<BuildingDTO> buildings { get; set; }
    }
}
