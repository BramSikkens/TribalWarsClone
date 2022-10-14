using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TribalWarsCloneDomain.Models.Buildings;

namespace TribalWarsCloneDomain.Models
{
    public class ConstructionList
    {
        private List<ConstructionItem> items;
        public Farm Farm { get; set; }
        public ConstructionList(Farm farm)
        {
            items = new List<ConstructionItem>();
            Farm = farm;
        }

        //When complete start the next item in the list
       public virtual void onCompleted(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Object Finished");
            //Return villagers to Farm
            Farm.PopulationInFarm += items[0].Cost.VillagerCost;
            //And then remove item from list
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

        public void AddItem(ConstructionItem item)
        {

           
            items.Add(item);
            items.Last().timer.Elapsed += this.onCompleted;

            if (items.Count == 1)
            {
                items[0].start();
            }
            else
            {
                Console.WriteLine("Object added to Queue");
            }
       
        }

        public void printItemsInList()
        {
            items.ForEach(e =>
            {
                e.printConstructionItem();
            });
        }

       
    }
}
