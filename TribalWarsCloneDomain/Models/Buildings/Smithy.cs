using System;

using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Timers;
using System.Xml.Serialization;
using TribalWarsCloneDomain.Interfaces;
using TribalWarsCloneDomain.Models.Soldiers;
using TribalWarsCloneDomain.utils;
using TribalWarsCloneDomain.utils.Interfaces;
using TribalWarsCloneDomain.utils.JSONWorldSettings;

namespace TribalWarsCloneDomain.Models.Buildings
{

    public interface ISmithy : IUpgradable, IArmyCreator, ISubjectSmithy, IPrint
    {
        ConstructionList developList { get; set;}
    }



    public class Smithy : Building, ISmithy
    {

        //IUpgradable
        public IFarm Farm { get; set; }
        public IWarehouse Warehouse { get; set; }

        //ISoldierCreator
        public Dictionary<string,Soldier> Soldiers { get; set; }

        public ConstructionList developList { get; set; }
        public List<IObserverSmitthy> SmitthyObservers { get ; set; }

        public SoldierFactory SoldierFactory { get; set; }


        public Smithy(IFarm farm, IWarehouse warehouse)
        {
            CurrentLevel = 1;
            Farm = farm;

            Warehouse = warehouse;

            SmitthyObservers = new List<IObserverSmitthy>();

            //?
            Soldiers = new Dictionary<string, Soldier>();
            Soldiers.Add(nameof(SpearSoldier), null);

            

            developList = new ConstructionList(Farm);
            SoldierFactory = new SoldierFactory();

           
        
        } 

        public void Downgrade()
        {
            throw new NotImplementedException();
        }

        public void WhenUpgradeIsComplete(object source, ElapsedEventArgs e)
        {
            CurrentLevel++;
            Console.WriteLine("Smithy Upgraded");
        }

        public void Upgrade(IConstructionList buildList)
        {
            //First we check if there is enough in the warehouse
            if (Warehouse.CheckEnoughResources(GetLevelCost(CurrentLevel + 1)))
            {
                //We create a buildTask(ITem) 
                ConstructionItem bi = new ConstructionItem(GetLevelCost(CurrentLevel +1), WhenUpgradeIsComplete);
                //And add it to the given list
                buildList.AddItem(bi);
                //Remove cost from Warehouse
                Warehouse.WithdrawResources(GetLevelCost(CurrentLevel + 1));
            }
            else
            {
                Console.WriteLine("Not enough EssentialResources");
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

                        if (Warehouse.CheckEnoughResources(WorldSettings.SpearSoldierCosts[1]))
                        {
                            Warehouse.WithdrawResources(WorldSettings.SpearSoldierCosts[1]);
                            ConstructionItem developSoldier = new ConstructionItem(WorldSettings.SpearSoldierCosts[1], (Object source, ElapsedEventArgs e) =>
                            {
                                Console.WriteLine("Soldier Developed");
                                Soldiers[nameof(SpearSoldier)] = SoldierFactory.CreateSpearSoldier();

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
                   
                    if (Warehouse.CheckEnoughResources(WorldSettings.SpearSoldierCosts[1]))
                    {
                        Warehouse.WithdrawResources(GetLevelCost(CurrentLevel));
                        ConstructionItem newSoldier = new ConstructionItem(WorldSettings.SpearSoldierCosts[1], (Object source, ElapsedEventArgs e) =>
                        {
                            Console.WriteLine("Soldier Trained -> Sent to RallyPoint");
                            NotifySoldierTrainingComplete(type, 1);
                        });
                        SoldierTrainingList.AddItem(newSoldier);
                    }
                    else
                    {
                        Console.WriteLine("Not enough EssentialResources Anymore");
                    }
                }
            }
            else
            {
                Console.WriteLine("Spear not yet developed");
            }
            
        }

        public void Print()
        {

            foreach(var item in Soldiers)
            {
                if(item.Value!= null)
                {
                   // Console.WriteLine("Unit:" +item.Key + " | WoodCost:{0} | ClayCost:{1} | IronCost:{2} | ProductionTime: {3}", item.Value.ProductionCost.WoodCost, item.Value.ProductionCost.ClayCost, item.Value.ProductionCost.WoodCost, item.Value.ProductionCost.ProductionTime);

                }
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

        public Cost GetLevelCost(int level)
        {
            return WorldSettings.SmithyProductionCosts[level.ToString()];
        }
    }
}
