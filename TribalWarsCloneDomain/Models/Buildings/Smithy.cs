using System;

using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Timers;
using System.Xml.Serialization;
using TribalWarsCloneDomain.Interfaces;
using TribalWarsCloneDomain.Models.Soldiers;
using TribalWarsCloneDomain.utils;

namespace TribalWarsCloneDomain.Models.Buildings 
{

    public interface ISmithy:IUpgradable,IArmyCreator,ISubjectSmithy
    {
        ConstructionList developList { get; set;}
        public void printBuildingInfo();
    }



    public class Smithy : Building, ISmithy
    {

        //IUpgradable
        public int MaxLevel { get; set; }
        public Cost ProductionCost { get; set; }
        public Cost DestructionReturn { get; set; }
        public IFarm Farm { get; set; }
        public IWarehouse Warehouse { get; set; }

        //ISoldierCreator
        public Dictionary<string,Soldier> Soldiers { get; set; }
        protected SpearSoldier spearSoldier;

        public ConstructionList developList { get; set; }
        public List<IObserverSmitthy> SmitthyObservers { get ; set; }



        public Smithy(Cost initialCost, IFarm farm,IWarehouse warehouse)
        {
            CurrentLevel = 1;
            ProductionCost = initialCost;
            MaxLevel = 20;
            Farm = farm;

            Warehouse = warehouse;

            SmitthyObservers = new List<IObserverSmitthy>();

            //?
            Soldiers = new Dictionary<string, Soldier>();
            Soldiers.Add(nameof(SpearSoldier), null);

            developList = new ConstructionList(Farm);
        
        } 

        public void Downgrade()
        {
            throw new NotImplementedException();
        }

        public void WhenUpgradeIsComplete(object source, ElapsedEventArgs e)
        {
            CurrentLevel++;
            DestructionReturn = ProductionCost;
            Console.WriteLine("Smithy Upgraded");

            ProductionCost.ClayCost = (int)Math.Round(ProductionCost.ClayCost * 1.5);
            ProductionCost.IronCost = (int)Math.Round(ProductionCost.IronCost * 1.5);
            ProductionCost.WoodCost = (int)Math.Round(ProductionCost.WoodCost * 1.5);
            ProductionCost.ProductionTime = (int)Math.Round(ProductionCost.ProductionTime * 1.5);
        }

        public void Upgrade(IConstructionList buildList)
        {
            //First we check if there is enough in the warehouse
            if (Warehouse.CheckEnoughResources(ProductionCost))
            {
                //We create a buildTask(ITem) 
                ConstructionItem bi = new ConstructionItem(this.ProductionCost, WhenUpgradeIsComplete);
                //And add it to the given list
                buildList.AddItem(bi);
                //Remove cost from Warehouse
                Warehouse.WithdrawResources(ProductionCost);
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
                        if (Warehouse.CheckEnoughResources(spearSoldierCost))
                        {
                            Warehouse.WithdrawResources(spearSoldierCost);
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
                    if (Warehouse.CheckEnoughResources(cost))
                    {
                        Warehouse.WithdrawResources(ProductionCost);
                        ConstructionItem newSoldier = new ConstructionItem(cost, (Object source, ElapsedEventArgs e) =>
                        {
                            Console.WriteLine("Soldier Trained -> Sent to RallyPoint");
                            NotifySoldierTrainingComplete(type, 1);
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
        
        public void Attach(IObserverSmitthy observer)
        {
            SmitthyObservers.Add(observer);
        }

        public void UnAttach(IObserverSmitthy observer)
        {
            throw new NotImplementedException();
        }




        public void NotifySoldierTrainingComplete(string type, int amount)
        {
            foreach (IObserverSmitthy o in SmitthyObservers)
            {
                o.UpdateRallyPoin(type, amount);
            }
        }

    }
}
