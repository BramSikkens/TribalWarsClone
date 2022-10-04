using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TribalWarsClone.Models.Buildings;

namespace TribalWarsClone.Models
{
    internal class BuildList
    {
        private List<BuildItem> items;

        public BuildList()
        {
            items = new List<BuildItem>();
        }
        void onCompleted(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Object Finished");
            items.RemoveAt(0); 
            if(items.Count > 0)
            {
                items[0].start();
            }
            else
            {
                Console.WriteLine("No more objects in List");
            }
        }

        public void AddItem(BuildItem item)
        {
           
            items.Add(item);

            if(items.Count == 1)
            {
                items[0].start();
            }
            else
            {
                Console.WriteLine("Object added to Queue");
            }
       
        }

    
    }
}
