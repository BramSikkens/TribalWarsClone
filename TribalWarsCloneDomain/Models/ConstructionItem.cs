using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TribalWarsCloneDomain.Models
{
    public class ConstructionItem
    {

        public System.Timers.Timer timer;
        public DateTime StartTime { get; set; }
        public DateTime endTime { get; set; }
        public String Status {get;set;}
        string Title { get; set; }
        public Cost Cost { get; set; }

      

        public ConstructionItem(Cost cost,ElapsedEventHandler onCompleted)
        {
            timer = new System.Timers.Timer(cost.ProductionTime);
            timer.AutoReset = false;
            timer.Enabled = false;
            timer.Elapsed += onCompleted;
            Cost = cost;
            Status = "Queued";
        }


        public void start()
        {
           timer.Enabled = true;
            StartTime = DateTime.Now;
            endTime = StartTime.AddMilliseconds(Cost.ProductionTime);
            Status = "Started";
            Console.WriteLine("Building Started");
        }

        public void printConstructionItem()
        {
            Console.WriteLine("Status:{0} | Starttime:{1} | koekek:{2} |Time Left: {3}", Status, StartTime.ToString(), endTime.ToString(),(endTime - DateTime.Now));
        }
    }
}
