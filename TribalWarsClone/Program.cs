// See https://aka.ms/new-console-template for more information
using TribalWarsCloneDomain.Models.Buildings;
using TribalWarsCloneDomain.Models;
using TribalWarsCloneDomain.Testing;
using System.Reflection.Metadata.Ecma335;
using System.Timers;


//Village v = new Village();

//displayOptions();
//string input = Console.ReadLine();



//while (input != "exit")
//{

//    if(input == "1")
//    {
//        v.printBuildings();
//    }
//    if (input == "2")
//    {
//        v.IronFactory.upgrade(v.BuildList,v.Warehouse,v.Farm);
//    }
//    if (input == "3")
//    {
//        v.WoodFactory.upgrade(v.BuildList, v.Warehouse,v.Farm);
//    }
//    if (input == "4")
//    {
//        v.ClayFactory.upgrade(v.BuildList, v.Warehouse,v.Farm);
//    }

//    if (input == "5")
//    {
//        v.Warehouse.PrintResources();
//    }

//    if(input == "6")
//    {
//        v.Warehouse.upgrade(v.BuildList, v.Warehouse,v.Farm);
//    }
//    if(input == "7")
//    {
//        v.BuildList.printItemsInList();
//    }
//    if(input == "8")
//    {
//        v.Farm.printFarmInfo();
//    }
//    if (input == "9")
//    {
//        v.Smithy.PrintInfo();
//    }

//    if (input == "10")
//    {
//        v.Smithy.developSpearSoldier();
//    }

//    if (input == "11")
//    {
//        v.Smithy.CreateSpearSoldier(10, v.RallyPoint);
//    }

//    if (input == "12")
//    {
//        v.RallyPoint.printInfo();
//    }



//    displayOptions();
//    input = Console.ReadLine();
//}



//void displayOptions(){
//    Console.WriteLine("Chooose Option");
//    Console.WriteLine("1) Print Buildings");
//    Console.WriteLine("2) Upgrade IronFactory");
//    Console.WriteLine("3) Upgrade WoodFactory");
//    Console.WriteLine("4) Upgrade ClayFactory");
//    Console.WriteLine("5) View Warehouse");
//    Console.WriteLine("6) Upgrade Warehouse");
//    Console.WriteLine("7) Print ConstructionList");
//    Console.WriteLine("8) Print Farm Info");
//    Console.WriteLine("9) Print Smithy Info");
//    Console.WriteLine("10) Develop Spear");
//    Console.WriteLine("11) Create soldiers");
//    Console.WriteLine("12) print rallypoint info");



//}

void onCompleted(Object source, ElapsedEventArgs onCompleted)
{
    Console.WriteLine("The whole list is ready!");
}

void onCompletedLeaf(Object source, ElapsedEventArgs onCompleted)
{
    Console.WriteLine("Leaf is ready");
}
Component SoldiersCreationList = new CreationComposite(new Cost { ClayCost = 0, IronCost = 0, WoodCost = 0, ProductionTime = 1, VillagerCost = 0 }, onCompleted);

Component SoldierCreation1 = new CreationLeaf(new Cost { ClayCost = 1, IronCost = 1, WoodCost = 1, ProductionTime = 10000, VillagerCost = 1 },onCompletedLeaf);
Component SoldierCreation2 = new CreationLeaf(new Cost { ClayCost = 1, IronCost = 1, WoodCost = 1, ProductionTime = 10000, VillagerCost = 1 }, onCompletedLeaf);
Component SoldierCreation3 = new CreationLeaf(new Cost { ClayCost = 1, IronCost = 1, WoodCost = 1, ProductionTime = 10000, VillagerCost = 1 }, onCompletedLeaf);
Component SoldierCreation4 = new CreationLeaf(new Cost { ClayCost = 1, IronCost = 1, WoodCost = 1, ProductionTime = 10000, VillagerCost = 1 }, onCompletedLeaf);
Component SoldierCreation5 = new CreationLeaf(new Cost { ClayCost = 1, IronCost = 1, WoodCost = 1, ProductionTime = 10000, VillagerCost = 1 }, onCompletedLeaf);
                                                                                                                        

SoldiersCreationList.Add(SoldierCreation1);
SoldiersCreationList.Add(SoldierCreation2);
SoldiersCreationList.Add(SoldierCreation3);
SoldiersCreationList.Add(SoldierCreation4);
SoldiersCreationList.Add(SoldierCreation5);

SoldiersCreationList.Start();

string input = Console.ReadLine();
while (input != "exit")
{
    input = Console.ReadLine();
}