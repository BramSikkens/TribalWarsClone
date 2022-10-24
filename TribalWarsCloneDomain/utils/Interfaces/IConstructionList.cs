using System;
using System.Collections.Generic;
using System.Timers;
using TribalWarsCloneDomain.Models;

namespace TribalWarsCloneDomain.Interfaces
{
    public interface IConstructionList:IPrint
    {
        public List<IConstructionItem> ConstructionItems { get; set; }
        public void AddItem(IConstructionItem item);
        public void WhenSingleListItemCompleted(Object source, ElapsedEventArgs e);
    }
}

