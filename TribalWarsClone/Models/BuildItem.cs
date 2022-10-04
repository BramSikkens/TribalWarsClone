using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TribalWarsClone.Models
{
    internal class BuildItem
    {

        private System.Timers.Timer timer;

        string Title { get; set; }

      

        public BuildItem(ProductionCost cost,ElapsedEventHandler onCompleted)
        {
            timer = new System.Timers.Timer(cost.ProductionTime);
            timer.AutoReset = false;
            timer.Enabled = false;
            timer.Elapsed += onCompleted; 
        }


       

        public void start()
        {
            timer.Enabled = true;
            Console.WriteLine("Building Started");
        }
    }
}
