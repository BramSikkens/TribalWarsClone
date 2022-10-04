using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TribalWarsClone.Models.Buildings;

namespace TribalWarsClone.Models
{
    internal class Village
    {

        public long Id { get; set; }
        public String Name { get; set; }
        public int currentLevel { get; set; }
        public Coordinates Location { get; set; }

        public Warehouse Warehouse { get; set; }

        public BuildingList BuildingList { get; set; }

        public IronFactory IronFactory { get; set; }

        public IDictionary<String,Building> Buildings { get; set; }

        public Village()
        {
            Warehouse = new Warehouse();
            IronFactory = new IronFactory();
            BuildingList = new BuildingList(); 
            
            //HeadQuarters hq = new HeadQuarters();

            //Buildings.Add(nameof(HeadQuarters), hq);
            //Buildings.Add(nameof(Farm), new Farm());
            //Buildings.Add(nameof(ClayFactory), new ClayFactory());
            //Buildings.Add(nameof(WoodFactory), new WoodFactory());
            //Buildings.Add(nameof(IronFactory), new IronFactory());
        }
    }

    
}
