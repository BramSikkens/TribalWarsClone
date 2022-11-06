using System;
using System.Collections.Generic;
using System.Net;
using TribalWarsCloneDomain.Models;
using TribalWarsCloneDomain.Models.Soldiers;

namespace TribalWarsCloneDomain.utils.JSONWorldSettings
{
    public class WorldSettings
    {

        public static bool IronMinebaseBuild = true;
        public static int IronMineMaxLevel = 3;
        public static Dictionary<int, Cost> IronMineProductionCosts = new Dictionary<int, Cost>()
        {
            { 1, new Cost(){
            WoodCost=0,
            IronCost=0,
            ClayCost=0,
            VillagerCost=0,
            ProductionTime=0} },

            { 2, new Cost(){
            WoodCost=2,
            IronCost=2,
            ClayCost=2,
            VillagerCost=2,
            ProductionTime=2000} },
                  { 3, new Cost(){
            WoodCost=3,
            IronCost=3,
            ClayCost=3,
            VillagerCost=3,
            ProductionTime=3000} }

        };

        public static bool TimberCampbaseBuild = true;
        public static int TimberCampMaxLevel = 3;
        public static Dictionary<int, Cost> TimberCampProductionCosts = new Dictionary<int, Cost>()
        {
            { 1, new Cost(){
            WoodCost=0,
            IronCost=0,
            ClayCost=0,
            VillagerCost=0,
            ProductionTime=0} },

               { 2, new Cost(){
            WoodCost=2,
            IronCost=2,
            ClayCost=2,
            VillagerCost=2,
            ProductionTime=2000} },
                  { 3, new Cost(){
            WoodCost=3,
            IronCost=3,
            ClayCost=3,
            VillagerCost=3,
            ProductionTime=3000} }

        };

        public static bool ClayPitbaseBuild = true;
        public static int ClayPitMaxLevel = 3;
        public static Dictionary<string, Cost> ClayPitProductionCosts = new Dictionary<string, Cost>()
        {
            { "1", new Cost(){
            WoodCost=0,
            IronCost=0,
            ClayCost=0,
            VillagerCost=0,
            ProductionTime=0} },
            { "2", new Cost(){
            WoodCost=2,
            IronCost=2,
            ClayCost=2,
            VillagerCost=2,
            ProductionTime=2000} },
                  { "3", new Cost(){
            WoodCost=3,
            IronCost=3,
            ClayCost=3,
            VillagerCost=3,
            ProductionTime=3000} }

        };

        public static bool WarehousebaseBuild = true;
        public static int WarehouseMaxLevel = 3;
        public static Dictionary<string, Cost> WarehouseProductionCosts = new Dictionary<string, Cost>()
        {
           { "1", new Cost(){
            WoodCost=0,
            IronCost=0,
            ClayCost=0,
            VillagerCost=0,
            ProductionTime=0} },
            { "2", new Cost(){
            WoodCost=2,
            IronCost=2,
            ClayCost=2,
            VillagerCost=2,
            ProductionTime=2000} },
                  { "3", new Cost(){
            WoodCost=3,
            IronCost=3,
            ClayCost=3,
            VillagerCost=3,
            ProductionTime=3000} }

        };


        public static bool FarmbaseBuild = true;
        public static int FarmMaxLevel = 3;
        public static Dictionary<string, Cost> FarmProductionCosts = new Dictionary<string, Cost>()
        {
           { "1", new Cost(){
            WoodCost=0,
            IronCost=0,
            ClayCost=0,
            VillagerCost=0,
            ProductionTime=0} },
            { "2", new Cost(){
            WoodCost=2,
            IronCost=2,
            ClayCost=2,
            VillagerCost=2,
            ProductionTime=2000} },
                  { "3", new Cost(){
            WoodCost=3,
            IronCost=3,
            ClayCost=3,
            VillagerCost=3,
            ProductionTime=3000} }

        };

        public static bool HeadQuartersbaseBuild = true;
        public static int HeadQuartersMaxLevel = 20;
        public static Dictionary<string, Cost> HeadQuartersProductionCosts = new Dictionary<string, Cost>()
        {
             { "1", new Cost(){
            WoodCost=0,
            IronCost=0,
            ClayCost=0,
            VillagerCost=0,
            ProductionTime=0} },
            { "2", new Cost(){
            WoodCost=2,
            IronCost=2,
            ClayCost=2,
            VillagerCost=2,
            ProductionTime=2000} },
                  { "3", new Cost(){
            WoodCost=3,
            IronCost=3,
            ClayCost=3,
            VillagerCost=3,
            ProductionTime=3000} }

        };

        public static bool RallyPointbaseBuild = true;
        public static int RallyPointMaxLevel = 1;
        public static Dictionary<int, Cost> RallyPointProductionCosts = new Dictionary<int, Cost>()
        {
        };



        public static bool SmithybaseBuild = false;
        public static int SmithyMaxLevel = 20;
        public static Dictionary<string, Cost> SmithyProductionCosts = new Dictionary<string, Cost>()
        {
             { "1", new Cost(){
            WoodCost=10,
            IronCost=10,
            ClayCost=10,
            VillagerCost=10,
            ProductionTime=1000} },
            { "2", new Cost(){
            WoodCost=20,
            IronCost=20,
            ClayCost=20,
            VillagerCost=2,
            ProductionTime=2000} },
                  { "3", new Cost(){
            WoodCost=30,
            IronCost=30,
            ClayCost=30,
            VillagerCost=3,
            ProductionTime=3000} }

        };

        public static Requirement SmithyRequirement = new Requirement()
        {
            BuildingRequirement = "IronMine",
            PropertyRequirement = "CurrentLevel",
            ValueRequirement = "2"
        };

        public static Dictionary<int, Cost> SpearSoldierCosts = new Dictionary<int, Cost>()
        {
            {  1,new Cost(){
            WoodCost=30,
            IronCost=30,
            ClayCost=30,
            VillagerCost=3,
            ProductionTime=3000}
            },{
             2,new Cost(){
            WoodCost=30,
            IronCost=30,
            ClayCost=30,
            VillagerCost=3,
            ProductionTime=3000}
            },{
             3,new Cost()
        {
            WoodCost = 30,
            IronCost = 30,
            ClayCost = 30,
            VillagerCost = 3,
            ProductionTime = 3000}
    },

        };

        public static Dictionary<int, Cost> AxeSoldierCosts = new Dictionary<int, Cost>()
        {
            {  1,new Cost(){
            WoodCost=30,
            IronCost=30,
            ClayCost=30,
            VillagerCost=3,
            ProductionTime=3000}
            },{
             2,new Cost(){
            WoodCost=30,
            IronCost=30,
            ClayCost=30,
            VillagerCost=3,
            ProductionTime=3000}
            },{
             3,new Cost()
        {
            WoodCost = 30,
            IronCost = 30,
            ClayCost = 30,
            VillagerCost = 3,
            ProductionTime = 3000}
    },

        };

        public static Dictionary<int, Cost> SwordSoldierCosts = new Dictionary<int, Cost>()
        {
            {  1,new Cost(){
            WoodCost=30,
            IronCost=30,
            ClayCost=30,
            VillagerCost=3,
            ProductionTime=3000}
            },{
             2,new Cost(){
            WoodCost=30,
            IronCost=30,
            ClayCost=30,
            VillagerCost=3,
            ProductionTime=3000}
            },{
             3,new Cost()
        {
            WoodCost = 30,
            IronCost = 30,
            ClayCost = 30,
            VillagerCost = 3,
            ProductionTime = 3000}
    },

        };

        public static Dictionary<int, Cost> ArcherySoldierCosts = new Dictionary<int, Cost>()
        {
            {  1,new Cost(){
            WoodCost=30,
            IronCost=30,
            ClayCost=30,
            VillagerCost=3,
            ProductionTime=3000}
            },{
             2,new Cost(){
            WoodCost=30,
            IronCost=30,
            ClayCost=30,
            VillagerCost=3,
            ProductionTime=3000}
            },{
             3,new Cost()
        {
            WoodCost = 30,
            IronCost = 30,
            ClayCost = 30,
            VillagerCost = 3,
            ProductionTime = 3000}
    },

        };


        public static Dictionary<int, SoldierStats> SpearSoldierStats = new Dictionary<int, SoldierStats>()
        {
            {1,
                new SoldierStats()
                {
                    Speed = 1,
                    Capacity = 1,
                    ArcheryDefence = 1,
                    AttackingPower = 1,
                    GeneralDefence = 1,
                    CavalaryDefence = 1,
                }
            },            {2,
                new SoldierStats()
                {
                    Speed = 1,
                    Capacity = 1,
                    ArcheryDefence = 1,
                    AttackingPower = 1,
                    GeneralDefence = 1,
                    CavalaryDefence = 1,
                }
            },            {3,
                new SoldierStats()
                {
                    Speed = 1,
                    Capacity = 1,
                    ArcheryDefence = 1,
                    AttackingPower = 1,
                    GeneralDefence = 1,
                    CavalaryDefence = 1,
                }
            }

            };

        public static Dictionary<int, SoldierStats> SwordSoldierStats = new Dictionary<int, SoldierStats>()
        {
            {1,
                new SoldierStats()
                {
                    Speed = 1,
                    Capacity = 1,
                    ArcheryDefence = 1,
                    AttackingPower = 1,
                    GeneralDefence = 1,
                    CavalaryDefence = 1,
                }
            },            {2,
                new SoldierStats()
                {
                    Speed = 1,
                    Capacity = 1,
                    ArcheryDefence = 1,
                    AttackingPower = 1,
                    GeneralDefence = 1,
                    CavalaryDefence = 1,
                }
            },            {3,
                new SoldierStats()
                {
                    Speed = 1,
                    Capacity = 1,
                    ArcheryDefence = 1,
                    AttackingPower = 1,
                    GeneralDefence = 1,
                    CavalaryDefence = 1,
                }
            }

            };

        public static Dictionary<int, SoldierStats> AxeSoldierStats = new Dictionary<int, SoldierStats>()
        {
            {1,
                new SoldierStats()
                {
                    Speed = 1,
                    Capacity = 1,
                    ArcheryDefence = 1,
                    AttackingPower = 1,
                    GeneralDefence = 1,
                    CavalaryDefence = 1,
                }
            },            {2,
                new SoldierStats()
                {
                    Speed = 1,
                    Capacity = 1,
                    ArcheryDefence = 1,
                    AttackingPower = 1,
                    GeneralDefence = 1,
                    CavalaryDefence = 1,
                }
            },            {3,
                new SoldierStats()
                {
                    Speed = 1,
                    Capacity = 1,
                    ArcheryDefence = 1,
                    AttackingPower = 1,
                    GeneralDefence = 1,
                    CavalaryDefence = 1,
                }
            }

            };

        public static Dictionary<int, SoldierStats> ArcherySoldierStats = new Dictionary<int, SoldierStats>()
        {
            {1,
                new SoldierStats()
                {
                    Speed = 1,
                    Capacity = 1,
                    ArcheryDefence = 1,
                    AttackingPower = 1,
                    GeneralDefence = 1,
                    CavalaryDefence = 1,
                }
            },            {2,
                new SoldierStats()
                {
                    Speed = 1,
                    Capacity = 1,
                    ArcheryDefence = 1,
                    AttackingPower = 1,
                    GeneralDefence = 1,
                    CavalaryDefence = 1,
                }
            },            {3,
                new SoldierStats()
                {
                    Speed = 1,
                    Capacity = 1,
                    ArcheryDefence = 1,
                    AttackingPower = 1,
                    GeneralDefence = 1,
                    CavalaryDefence = 1,
                }
            }

            };


    }
}

