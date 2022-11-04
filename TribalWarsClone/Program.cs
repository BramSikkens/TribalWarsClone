// See https://aka.ms/new-console-template for more information
using TribalWarsCloneDomain.Models.Buildings;
using TribalWarsCloneDomain.Models;
using System.Reflection.Metadata.Ecma335;
using System.Timers;
using TribalWarsCloneDomain.Models.Soldiers;
using TribalWarsCloneDomain.utils.Interfaces;
using TribalWarsCloneDomain.utils.JSONWorldSettings;

IVillage v = null;
World world = new World(); 

start();


 void start()
{
    //displayWorldMenu();
    //WorldDTO dto =  WorldSettingsReader.Read<WorldDTO>("C:\\Users\\Bram Sikkens\\Desktop\\TribalWarsClone\\TribalWarsClone\\World1.json");
    //Console.WriteLine(dto);
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
            case "1": world.showInfo();break;
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
        Console.Write("Give me your name: ");
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
    Console.WriteLine("2)IronMine");
    Console.WriteLine("3)ClayPit");
    Console.WriteLine("4)TimberCamp");
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
            case "1": v.Print();break;
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

    Console.WriteLine("------IronMine----");
    Console.WriteLine("1)Show Info");
    Console.WriteLine("2)Upgrade");
    Console.WriteLine("3)Downgrade");
    Console.WriteLine("4)Go Back");

    string input = "";
    while (input != "exit")
    {
        switch (input)
        {
            case "1": v.IronMine.Print();break;
            case "2": v.IronMine.Upgrade(v.BuildList);break;
            case "3": v.IronMine.Downgrade();break;
            case "4": displayVillageMenu(); break;
            
        }

        Console.Write("input:");
        input = Console.ReadLine();
    }
}

void displayWoodFactoryMenu()
{

    Console.WriteLine("------TimberCamp----");
    Console.WriteLine("1)Show Info");
    Console.WriteLine("2)Upgrade");
    Console.WriteLine("3)Downgrade");
    Console.WriteLine("4)Go Back");

    string input = "";
    while (input != "exit")
    {
        switch (input)
        {
            case "1": v.TimberCamp.Print(); break;
            case "2": v.TimberCamp.Upgrade(v.BuildList); break;
            case "3": v.TimberCamp.Downgrade(); break;
            case "4": displayVillageMenu(); break;

        }

        Console.Write("input:");
        input = Console.ReadLine();
    }
}

void displayClayFactoryMenu()
{

    Console.WriteLine("------ClayPit----");
    Console.WriteLine("1)Show Info");
    Console.WriteLine("2)Upgrade");
    Console.WriteLine("3)Downgrade");
    Console.WriteLine("4)Go Back");

    string input = "";
    while (input != "exit")
    {
        switch (input)
        {
            case "1": v.ClayPit.Print(); break;
            case "2": v.ClayPit.Upgrade(v.BuildList); break;
            case "3": v.ClayPit.Downgrade(); break;
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
            case "1": (v.Warehouse as Warehouse).Print(); break;
            case "2": (v.Warehouse as IUpgradable).Upgrade(v.BuildList); break;
            case "3": (v.Warehouse as IUpgradable).Downgrade(); break;
            case "4": displayVillageMenu(); break;

        }

        Console.Write("input:");
        input = Console.ReadLine();
    }
}

void displaySmithyMenu()
{


    string input = "";
    while (input != "exit")
    {
        if (v.Smithy != null)
        {
            Console.WriteLine("------Smithy----");
            Console.WriteLine("1)Show Info");
            Console.WriteLine("2)Upgrade");
            Console.WriteLine("3)Downgrade");
            Console.WriteLine("4)Develop Spear");
            Console.WriteLine("5)Train Spear");
            Console.WriteLine("6)Go Back");

            switch (input)
            {
                case "1": v.Smithy.Print(); break;
                case "2": v.Smithy.Upgrade(v.BuildList); break;
                case "3": v.Smithy.Downgrade(); break;
                case "4": v.Smithy.developSoldier(nameof(SpearSoldier)); break;
                case "5":
                    {
                        Console.Write("Amount");
                        string amount = Console.ReadLine();
                        v.Smithy.TrainSoldier(nameof(SpearSoldier), int.Parse(amount));


                    }; break;
                case "6": displayVillageMenu(); break;

            }
        }
        else
        {
            Console.WriteLine("Smithy is not yet developed");
            Console.WriteLine("1)Create Smithy");
            Console.WriteLine("6)Go Back");

            switch (input)
            {
                case "1": {
                        v.AddSmithy();
                        displayVillageMenu();
                    }; break;
                case "6": displayVillageMenu(); break;
            }
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
            case "1": v.RallyPoint.Print(); break;
            case "4": displayVillageMenu(); break;

        }

        Console.Write("input:");
        input = Console.ReadLine();
    }
}