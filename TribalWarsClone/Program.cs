// See https://aka.ms/new-console-template for more information
using TribalWarsCloneDomain.Models.Buildings;
using TribalWarsCloneDomain.Models;
using TribalWarsCloneDomain.Testing;
using System.Reflection.Metadata.Ecma335;
using System.Timers;
using TribalWarsCloneDomain.Models.Soldiers;

Village v = null;

//displayOptions();
//string input = Console.ReadLine();



//while (input != "exit")
//{

//    if (input == "1")
//    {
//        v.printBuildings();
//    }
//    if (input == "2")
//    {
//        v.IronFactory.upgrade(v.BuildList);
//    }
//    if (input == "3")
//    {
//        v.WoodFactory.upgrade(v.BuildList);
//    }
//    if (input == "4")
//    {
//        v.ClayFactory.upgrade(v.BuildList);
//    }

//    if (input == "5")
//    {
//        v.Warehouse.PrintResources();
//    }

//    if (input == "6")
//    {
//        v.Warehouse.upgrade(v.BuildList, v.Warehouse, v.Farm);
//    }
//    if (input == "7")
//    {
//        v.BuildList.printItemsInList();
//    }
//    if (input == "8")
//    {
//        v.Farm.printFarmInfo();
//    }
//    if (input == "9")
//    {
//        v.Smithy.PrintInfo();
//    }

//    if (input == "10")
//    {
//        v.Smithy.developSoldier(nameof(SpearSoldier));
//    }

//    if (input == "11")
//    {
//        v.Smithy.TrainSoldier(nameof(SpearSoldier), 1);
//    }

//    if (input == "12")
//    {
//        v.RallyPoint.printInfo();
//    }



//    displayOptions();
//    input = Console.ReadLine();
//}



//void displayOptions()
//{
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

World world = new World(); 

start();


void start()
{
    displayWorldMenu();

}

void displayWorldMenu()
{
    Console.WriteLine("------World----");
    Console.WriteLine("1)Show Info");
    Console.WriteLine("2)Create New Village");
    Console.WriteLine("3)Change Village");
    Console.WriteLine("exit");

    string input = "";
    while (input != "exit")
    {
        switch (input)
        {
            case "1": Console.WriteLine("not yet");break;
            case "2": createNewVillage();break;
            case "3": changeVillage();break;
       

        }

        Console.Write("input:");
        input = Console.ReadLine();
    }
}

void createNewVillage()
{
    
        Console.WriteLine("Hello! Welcome to TribalClone");
        Console.Write("Give me your name");
        string name = Console.ReadLine();
        Console.Write("Tell me the name of your village: ");
        string newVillageName = Console.ReadLine();
        world.createNewVillage(name, newVillageName);
        Console.WriteLine(newVillageName + " is created");
        v = world.Villages[name];
    
    displayVillageMenu();
}

void changeVillage()
{
    Console.WriteLine("------World-----");
    Console.Write("Give your name to set Village: ");
    string name = Console.ReadLine();

    if (world.Villages.ContainsKey(name))
    {
        v = world.Villages[name];
        displayVillageMenu();
    }
    else
    {
        Console.WriteLine("Village does not exist");
        displayWorldMenu();
        
    }

  
 

}

void displayVillageMenu()
{

    Console.WriteLine("------Village-----"); 
    Console.WriteLine("1)Show VillageInfo");
    Console.WriteLine("2)IronFactory");
    Console.WriteLine("3)ClayFactory");
    Console.WriteLine("4)WoodFactory");
    Console.WriteLine("5)Warehouse");
    Console.WriteLine("6)Smithy");
    Console.WriteLine("7)RallyPoint");
    Console.WriteLine("8)Change Village");
    Console.WriteLine("exit");
    string input = "";
    while (input != "exit")
    {
        switch (input)
        {
            case "1": v.showInfo();break;
            case "2": displayIronFactoryMenu(); break;
            case "3": displayClayFactoryMenu(); break;
            case "4": displayWoodFactoryMenu(); break;
            case "5":displayWarehouseMenu(); break;
            case "6": displaySmithyMenu(); break;
            case "7":displayRallyPointMenu(); break;
            case "8":displayWorldMenu();break;
            

        }

        Console.Write("input:");
        input = Console.ReadLine();
    }
}

void displayIronFactoryMenu()
{

    Console.WriteLine("------IronFactory----");
    Console.WriteLine("1)Show Info");
    Console.WriteLine("2)Upgrade");
    Console.WriteLine("3)Downgrade");
    Console.WriteLine("4)Go Back");

    string input = "";
    while (input != "exit")
    {
        switch (input)
        {
            case "1": v.IronFactory.printBuildingInfo();break;
            case "2": v.IronFactory.upgrade(v.BuildList);break;
            case "3": v.IronFactory.downgrade();break;
            case "4": displayVillageMenu(); break;
            
        }

        Console.Write("input:");
        input = Console.ReadLine();
    }
}

void displayWoodFactoryMenu()
{

    Console.WriteLine("------WoodFactory----");
    Console.WriteLine("1)Show Info");
    Console.WriteLine("2)Upgrade");
    Console.WriteLine("3)Downgrade");
    Console.WriteLine("4)Go Back");

    string input = "";
    while (input != "exit")
    {
        switch (input)
        {
            case "1": v.WoodFactory.printBuildingInfo(); break;
            case "2": v.WoodFactory.upgrade(v.BuildList); break;
            case "3": v.WoodFactory.downgrade(); break;
            case "4": displayVillageMenu(); break;

        }

        Console.Write("input:");
        input = Console.ReadLine();
    }
}

void displayClayFactoryMenu()
{

    Console.WriteLine("------ClayFactory----");
    Console.WriteLine("1)Show Info");
    Console.WriteLine("2)Upgrade");
    Console.WriteLine("3)Downgrade");
    Console.WriteLine("4)Go Back");

    string input = "";
    while (input != "exit")
    {
        switch (input)
        {
            case "1": v.ClayFactory.printBuildingInfo(); break;
            case "2": v.ClayFactory.upgrade(v.BuildList); break;
            case "3": v.ClayFactory.downgrade(); break;
            case "4": displayVillageMenu(); break;

        }

        Console.Write("input:");
        input = Console.ReadLine();
    }
}

void displayWarehouseMenu()
{

    Console.WriteLine("------Warehouse----");
    Console.WriteLine("1)Show Info");
    Console.WriteLine("2)Upgrade");
    Console.WriteLine("3)Downgrade");
    Console.WriteLine("4)Go Back");

    string input = "";
    while (input != "exit")
    {
        switch (input)
        {
            case "1": v.Warehouse.printBuildingInfo(); break;
            case "2": v.Warehouse.upgrade(v.BuildList); break;
            case "3": v.Warehouse.downgrade(); break;
            case "4": displayVillageMenu(); break;

        }

        Console.Write("input:");
        input = Console.ReadLine();
    }
}

void displaySmithyMenu()
{
    Console.WriteLine("------Smithy----");
    Console.WriteLine("1)Show Info");
    Console.WriteLine("2)Upgrade");
    Console.WriteLine("3)Downgrade");
    Console.WriteLine("4)Develop Spear");
    Console.WriteLine("5)Train Spear");
    Console.WriteLine("6)Go Back");

    string input = "";
    while (input != "exit")
    {
        switch (input)
        {
            case "1": v.Smithy.printBuildingInfo(); break;
            case "2": v.Smithy.upgrade(v.BuildList); break;
            case "3": v.Smithy.downgrade(); break;
            case "4": v.Smithy.developSoldier(nameof(SpearSoldier));break;
            case "5":
                {
                    Console.Write("Amount");
                    string amount = Console.ReadLine();
                    v.Smithy.TrainSoldier(nameof(SpearSoldier),int.Parse(amount));
            
                    
                };break;
            case "6": displayVillageMenu(); break;

        }

        Console.Write("input:");
        input = Console.ReadLine();
    }
}

void displayRallyPointMenu()
{

    Console.WriteLine("------RallyPoint----");
    Console.WriteLine("1)Show Info");
    Console.WriteLine("4)Go Back");

    string input = "";
    while (input != "exit")
    {
        switch (input)
        {
            case "1": v.RallyPoint.printBuildingInfo(); break;
            case "4": displayVillageMenu(); break;

        }

        Console.Write("input:");
        input = Console.ReadLine();
    }
}