using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TribalWarsCloneDomain.Models
{
    public class BuildItem
    {

        public System.Timers.Timer timer;
        string Title { get; set; }
        Cost cost { get; set; }

      

        public BuildItem(Cost cost,ElapsedEventHandler onCompleted)
        {
            timer = new System.Timers.Timer(cost.ProductionTime);
            timer.AutoReset = false;
            timer.Enabled = false;
            timer.Elapsed += onCompleted;
            cost = cost;
        }


       

        public void start()
        {
            timer.Enabled = true;
            Console.WriteLine("Building Started");
        }
    }
}
