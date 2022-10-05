using System.Timers;

namespace TribalWarsCloneDomain.Models
{
     public class Filler
    {
        private System.Timers.Timer timer;
        public Filler(int timerInterval,ElapsedEventHandler handler)
        {
            timer = new System.Timers.Timer(timerInterval);
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Elapsed += handler;

          
        }
    }
}