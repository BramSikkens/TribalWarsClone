using System;
using TribalWarsCloneDomain.utils.JSONWorldSettings;

namespace TribalWarsCloneDomain.Models.Soldiers
{
    public interface ISoldierFactory
    {
        public SwordSoldier CreateSwordSoldier();
        public SpearSoldier CreateSpearSoldier();
        public AxeSoldier CreateAxeSoldier();
        public ArcherySoldier CreateArcherySoldier();
    }

    public class SoldierFactory:ISoldierFactory
    {
        public SoldierFactory()
        {
        }

        public ArcherySoldier CreateArcherySoldier()
        {
            return new ArcherySoldier(WorldSettings.ArcherySoldierStats[1]);
        }

        public AxeSoldier CreateAxeSoldier()
        {
            return new AxeSoldier( WorldSettings.AxeSoldierStats[1]);
        }

        public SpearSoldier CreateSpearSoldier()
        {
            return new SpearSoldier(WorldSettings.SpearSoldierStats[1]);
        }

        public SwordSoldier CreateSwordSoldier()
        {
            return new SwordSoldier(WorldSettings.SwordSoldierStats[1]);
        }
    }
}

