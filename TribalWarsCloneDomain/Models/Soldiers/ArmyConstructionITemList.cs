using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace TribalWarsCloneDomain.Models.Soldiers
{
    internal class ArmyConstructionItem : ConstructionItem
    {
        public int AmountofSoldiers;

        public ArmyConstructionItem(Cost cost, ElapsedEventHandler onCompleted, int amountofSoldiers) : base(cost, onCompleted)
        {
            AmountofSoldiers = amountofSoldiers;
        }
    }
}
