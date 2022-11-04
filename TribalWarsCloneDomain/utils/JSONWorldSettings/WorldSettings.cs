using System;
using System.Collections.Generic;
using TribalWarsCloneDomain.Models;

namespace TribalWarsCloneDomain.utils.JSONWorldSettings
{
    public class WorldSettings
    {

        public static bool IronMinebaseBuild = true;
        public static int IronMineMaxLevel = 20;
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
        public static int TimberCampMaxLevel = 20; 
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
        public static int ClayPitMaxLevel = 20; 
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
        public static int WarehouseMaxLevel = 20;
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
        public static int FarmMaxLevel = 20;
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

    }
}

