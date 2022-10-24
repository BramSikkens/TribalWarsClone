using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TribalWarsCloneDomain.Interfaces;
using TribalWarsCloneDomain.Models.Buildings;

namespace TribalWarsCloneDomain.Models
{


    public class ConstructionList:IConstructionList
    {
        public List<IConstructionItem> ConstructionItems { get; set; }
        public IFarm Farm { get; set; }
        public ConstructionList(IFarm farm)
        {
            ConstructionItems = new List<IConstructionItem>();
            Farm = farm;
        }

        //When complete start the next item in the list
       public  void WhenSingleListItemCompleted(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Object Finished");
            ConstructionItems.RemoveAt(0); 
            if(ConstructionItems.Count > 0)
            {
                ConstructionItems[0].StartItemTimer();
            }
            else
            {
                Console.WriteLine("No more objects in List");
            }
        }

        public void AddItem(IConstructionItem item)
        {

            ConstructionItems.Add(item);
            ConstructionItems.Last().Timer.Elapsed += this.WhenSingleListItemCompleted;

            if (ConstructionItems.Count == 1)
            {
                ConstructionItems[0].StartItemTimer();
            }
       
        }

 

        public void Print()
        {
            ConstructionItems.ForEach(e =>
            {
                e.Print();
            });
        }

       
    }
}
