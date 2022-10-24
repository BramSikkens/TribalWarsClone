using System;
using TribalWarsCloneDomain.Models;

namespace TribalWarsCloneDomain.utils.Interfaces
{
    public interface IResourceble
    {
        public void UpdateResources();
        public void WithdrawResources(Cost cost);
        public Boolean CheckEnoughResources(Cost cost);
    }
}

