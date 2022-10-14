using System;

using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Timers;
using System.Xml.Serialization;
using TribalWarsCloneDomain.Models.Soldiers;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public class Smithy : Building, IUpgradable
    {

        public int MaxLevel { get; set; }

        public Cost ProductionCost { get; set; }
        public Cost DestructionReturn { get; set; }


        protected SpearSoldier spearSoldier;
        
        public Smithy(Cost initialCost)
        {
            CurrentLevel = 1;
            ProductionCost = initialCost;
            MaxLevel = 20;
            spearSoldier = null;

        } 

        public void downgrade()
        {
            throw new NotImplementedException();
        }

        public void onUpgradeComplete(object source, ElapsedEventArgs e)
        {
            CurrentLevel++;
            DestructionReturn = ProductionCost;
            Console.WriteLine("Smithy Upgraded");

            ProductionCost.ClayCost = (int)Math.Round(ProductionCost.ClayCost * 1.5);
            ProductionCost.IronCost = (int)Math.Round(ProductionCost.IronCost * 1.5);
            ProductionCost.WoodCost = (int)Math.Round(ProductionCost.WoodCost * 1.5);
            ProductionCost.ProductionTime = (int)Math.Round(ProductionCost.ProductionTime * 1.5);
        }

        public void upgrade(ConstructionList buildList, Warehouse warehouse, Farm farm)
        {
            //First we check if there is enough in the warehouse
            if (warehouse.checkEnoughResources(ProductionCost))
            {
                //We create a buildTask(ITem) 
                ConstructionItem bi = new ConstructionItem(this.ProductionCost, onUpgradeComplete);
                //And add it to the given list
                buildList.AddItem(bi);
                //Remove cost from Warehouse
                warehouse.withdrawResources(ProductionCost.ClayCost, ProductionCost.IronCost, ProductionCost.WoodCost);
            }
            else
            {
                Console.WriteLine("Not enough Resources");
            }
        }

        public void developSpearSoldier()
        {
            spearSoldier = new SpearSoldier(new Cost { ClayCost = 30, IronCost = 10, WoodCost = 50, VillagerCost = 1, ProductionTime = 5021 }, 18, 25, 10, 15, 45, 20);
        }

        public Boolean isSpearSoldierDeveloped()
        {
            if (spearSoldier != null) return true; else return false;
        }

        public void CreateSpearSoldier(int amount,RallyPoint rallyPoint)
        {
            if (isSpearSoldierDeveloped())
            {
                rallyPoint.SpearSoldierAmount += amount;
            }
            else
            {
                Console.WriteLine("Spear not yet developed");
                    
            }
            
        }

        public void PrintInfo()
        {
            if(spearSoldier != null)
            {
                Console.WriteLine("Unit:SpearSolder | WoodCost:{0} | ClayCost:{1} | IronCost:{2} | ProductionTime: {3}", spearSoldier.ProductionCost.WoodCost, spearSoldier.ProductionCost.ClayCost, spearSoldier.ProductionCost.WoodCost, spearSoldier.ProductionCost.ProductionTime);
            }
            else
            {
                Console.WriteLine("Unit:SpearSoldier | Not yet developed");
            }
        }

    }
}
