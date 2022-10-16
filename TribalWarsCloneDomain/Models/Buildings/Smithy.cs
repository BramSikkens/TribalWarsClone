using System;

using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Timers;
using System.Xml.Serialization;
using TribalWarsCloneDomain.Models.Soldiers;

namespace TribalWarsCloneDomain.Models.Buildings
{
    public class Smithy : Building, IUpgradable, IArmyCreator
    {

        //IUpgradable
        public int MaxLevel { get; set; }
        public Cost ProductionCost { get; set; }
        public Cost DestructionReturn { get; set; }
        public Farm Farm { get; set; }
        public Warehouse Warehouse { get; set; }

        //ISoldierCreator
        public RallyPoint RallyPoint { get; set; }

        public Dictionary<string,Soldier> Soldiers { get; set; }

        protected SpearSoldier spearSoldier;

        public ConstructionList developList { get; set; }

        
        public Smithy(Cost initialCost,RallyPoint rallyPoint, Farm farm,Warehouse warehouse)
        {
            CurrentLevel = 1;
            ProductionCost = initialCost;
            MaxLevel = 20;
            Farm = farm;
            RallyPoint = rallyPoint;
            Warehouse = warehouse;

            //?
            Soldiers = new Dictionary<string, Soldier>();
            Soldiers.Add(nameof(SpearSoldier), null);

            developList = new ConstructionList(Farm);
        
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

        public void upgrade(ConstructionList buildList)
        {
            //First we check if there is enough in the warehouse
            if (Warehouse.checkEnoughResources(ProductionCost))
            {
                //We create a buildTask(ITem) 
                ConstructionItem bi = new ConstructionItem(this.ProductionCost, onUpgradeComplete);
                //And add it to the given list
                buildList.AddItem(bi);
                //Remove cost from Warehouse
                Warehouse.withdrawResources(ProductionCost.ClayCost, ProductionCost.IronCost, ProductionCost.WoodCost);
            }
            else
            {
                Console.WriteLine("Not enough Resources");
            }
        }

        public void developSoldier(string type)
        {
            if(isSoldierDeveloped(type))
            {
                Console.WriteLine("Soldier is alrady developed");
                return; 
            }
            
            switch (type)
            {
                case nameof(SpearSoldier):
                    {
                        Cost spearSoldierCost = new Cost { ClayCost = 3, IronCost = 1, WoodCost = 5, VillagerCost = 1, ProductionTime = 5021 };
                        if (Warehouse.checkEnoughResources(spearSoldierCost))
                        {
                            Warehouse.withdrawResources(spearSoldierCost.ClayCost, spearSoldierCost.ClayCost, spearSoldierCost.WoodCost);
                            ConstructionItem developSoldier = new ConstructionItem(spearSoldierCost, (Object source, ElapsedEventArgs e) =>
                            {
                                Console.WriteLine("Soldier Developed");
                                Cost upgradedSpearSoldierCost = new Cost { ClayCost = 5, IronCost = 3, WoodCost = 3, VillagerCost = 1, ProductionTime = 1000 };
                                Soldiers[nameof(SpearSoldier)] = new SpearSoldier(upgradedSpearSoldierCost, 18, 25, 10, 15, 45, 20);

                            });

                            developList.AddItem(developSoldier);
                            
                            
                        }
                        else Console.WriteLine("Not enough resources to develop Soldier");
                    }
                    break;
            }


        }

        public Boolean isSoldierDeveloped(string type)
        {
            if (Soldiers[type] != null) return true; else return false;
        }



        public void TrainSoldier(string type,int amount)
        {
            if (isSoldierDeveloped(type))
            {
                ConstructionList SoldierTrainingList = new ConstructionList(Farm); 
                for(int i =0; i < amount; i++)
                {
                    Cost cost = Soldiers[type].ProductionCost;
                    if (Warehouse.checkEnoughResources(cost))
                    {
                        Warehouse.withdrawResources(cost.ClayCost, cost.ClayCost, cost.WoodCost);
                        ConstructionItem newSoldier = new ConstructionItem(cost, (Object source, ElapsedEventArgs e) =>
                        {
                            Console.WriteLine("Soldier Trained -> Sent to RallyPoint");
                            RallyPoint.AddSoldierToRallyPoint(type, 1);
                        });
                        SoldierTrainingList.AddItem(newSoldier);
                    }
                    else
                    {
                        Console.WriteLine("Not enough Resources Anymore");
                    }
                }
            }
            else
            {
                Console.WriteLine("Spear not yet developed");
            }
            
        }

        public void printBuildingInfo()
        {

            foreach(var item in Soldiers)
            {
                if(item.Value!= null)
                {
                    Console.WriteLine("Unit:" +item.Key + " | WoodCost:{0} | ClayCost:{1} | IronCost:{2} | ProductionTime: {3}", item.Value.ProductionCost.WoodCost, item.Value.ProductionCost.ClayCost, item.Value.ProductionCost.WoodCost, item.Value.ProductionCost.ProductionTime);

                }
            }


            if(spearSoldier != null)
            {
            }
            else
            {
                Console.WriteLine("Unit:SpearSoldier | Not yet developed");
            }
        }

    }
}
