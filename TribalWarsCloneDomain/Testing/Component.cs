using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TribalWarsCloneDomain.Models;

namespace TribalWarsCloneDomain.Testing
{
    public abstract class Component
    {
        public DateTime StartTime { get; set; }
        public DateTime Endtime { get; set; }
        public Cost Cost { get; set; }
        public System.Timers.Timer timer;
        public String Status { get; set; }
        public Boolean Completed { get; set; } = false;

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void onCompleted(Object source, ElapsedEventArgs onCompleted);

        public abstract void Start();

        public Component(Cost cost, ElapsedEventHandler onCompleted)
        {

        }

    }

    public class CreationComposite : Component
    {
        List<Component> children = new List<Component>();
        Boolean startedLastOne = false;

        public CreationComposite(Cost cost, ElapsedEventHandler onCompleted) : base(cost, onCompleted)
        {
            timer = new System.Timers.Timer(1);
            timer.AutoReset = false;
            timer.Enabled = false;
            timer.Elapsed += this.onCompleted;
            Cost = cost;
            Status = "Queued";
        }

        public override void Add(Component c)
        {

            Cost.ProductionTime += c.Cost.ProductionTime;
            timer = new System.Timers.Timer(Cost.ProductionTime);
            Console.WriteLine("Child Added");
            children.Add(c);
        }

        public override void onCompleted(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Whole List is finished");
        }

        public override void Remove(Component c)
        {
            throw new NotImplementedException();
        }

        public override void Start()
        {
           timer.Enabled=true;
           for(int i =0; i<children.Count; i++)
            {
                if (i > 0)
                {
                    while (children[i-1].Completed != true )
                    {
                        Console.WriteLine("Building Item {0}",i);

                     
                    }
                }

                children[i].Start();
           
            }
        }
    }

    public class CreationLeaf : Component
    {
        public CreationLeaf(Cost cost, ElapsedEventHandler onCompleted) : base(cost, onCompleted)
        {
            timer = new System.Timers.Timer(cost.ProductionTime);
            timer.AutoReset = false;
            timer.Enabled = false;
            timer.Elapsed += this.onCompleted;
            Cost = cost;
            Status = "Queued";
        }

        public override void Add(Component c)
        {
            Console.WriteLine("Leaf can't add component"); 
        }

        public override void onCompleted(object source, ElapsedEventArgs onCompleted)
        {
            Completed = true;
            Console.WriteLine("Single Item completed");
        }

        public override void Remove(Component c)
        {
            throw new NotImplementedException();
        }

        public override void Start()
        {
            timer.Enabled = true;
            Status = "Started";
            Console.WriteLine("Building Started");
        }
    }
}


