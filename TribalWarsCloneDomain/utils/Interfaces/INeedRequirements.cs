using System;
using System.Collections.Generic;
using System.Text;

namespace TribalWarsCloneDomain.utils.Interfaces
{
    public interface INeedRequirements
    {
        public List<string> requiredObjects { get; set; }
        public Dictionary<string, string> requiredProperties { get; set; }

    }
}
