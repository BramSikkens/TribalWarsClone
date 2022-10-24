using System;
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
            Cost cost = new Cost { ClayCost = 3, IronCost = 1, WoodCost = 5, VillagerCost = 1, ProductionTime = 5021 };
            return new ArcherySoldier(cost, 18, 25, 10, 15, 45, 20);
        }

        public AxeSoldier CreateAxeSoldier()
        {
            Cost cost = new Cost { ClayCost = 3, IronCost = 1, WoodCost = 5, VillagerCost = 1, ProductionTime = 5021 };
            return new AxeSoldier(cost, 18, 25, 10, 15, 45, 20);
        }

        public SpearSoldier CreateSpearSoldier()
        {
            Cost spearSoldierCost = new Cost { ClayCost = 3, IronCost = 1, WoodCost = 5, VillagerCost = 1, ProductionTime = 5021 };
            return new SpearSoldier(spearSoldierCost, 18, 25, 10, 15, 45, 20);
        }

        public SwordSoldier CreateSwordSoldier()
        {
            Cost cost = new Cost { ClayCost = 3, IronCost = 1, WoodCost = 5, VillagerCost = 1, ProductionTime = 5021 };
            return new SwordSoldier(cost, 18, 25, 10, 15, 45, 20);
        }
    }
}

