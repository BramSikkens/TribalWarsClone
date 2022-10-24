using System;
using System.Collections.Generic;
using System.Text;

namespace TribalWarsCloneDomain.Models
{
    public class World
    {
        public string Id { get; set; }
        public Dictionary<string,Village> Villages { get; set; }

        public World()
        {
            Villages = new Dictionary<string, Village>();
        }

        public void createNewVillage(string userId, string name)
        {
            Village newVillage = new Village(name);
            Villages.Add(userId,newVillage);
        }

        public void showInfo()
        {
            foreach(var item in Villages)
            {
                item.Value.Print();
            }
        }
      
    }
}
