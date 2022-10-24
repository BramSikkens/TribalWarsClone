using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TribalWarsCloneDomain.Interfaces;

namespace TribalWarsCloneDomain.Models
{

    public class ConstructionItem:IConstructionItem
    {
        public System.Timers.Timer Timer { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public String Status {get;set;}
        public String Title { get; set; }
        public Cost Cost { get; set; }

        public ConstructionItem(Cost cost,ElapsedEventHandler onCompleted)
        {
            Timer = new System.Timers.Timer(cost.ProductionTime);
            Timer.AutoReset = false;
            Timer.Enabled = false;
            Timer.Elapsed += onCompleted;
            Cost = cost;
            Status = "Queued";
        }

       


        public void StartItemTimer()
        {
            Timer.Enabled = true;
            StartTime = DateTime.Now;
            EndTime = StartTime.AddMilliseconds(Cost.ProductionTime);
            Status = "Started";
            Print();
        }

        public void Print()
        {
            Console.WriteLine("Status:{0} | Starttime:{1} | EndTime:{2} |Time Left: {3}", Status, StartTime.ToString(), EndTime.ToString(),(EndTime - DateTime.Now));
        }
    }
}
