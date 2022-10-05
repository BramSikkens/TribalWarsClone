using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TribalWarsCloneDomain.Models.Buildings;

namespace TribalWarsCloneDomain.Models
{
    public class BuildList
    {
        private List<BuildItem> items;
        public BuildList()
        {
            items = new List<BuildItem>();
        }

        //When complete start the next item in the list
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
            items[0].timer.Elapsed += this.onCompleted;

            if (items.Count == 1)
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
