﻿// See https://aka.ms/new-console-template for more information
using TribalWarsCloneDomain.Models.Buildings;
using TribalWarsCloneDomain.Models;


Village v = new Village();

displayOptions();
string input = Console.ReadLine();



while (input != "exit")
{

    if(input == "1")
    {
        v.printBuildings();
    }
    if (input == "2")
    {
        v.IronFactory.upgrade(v.BuildList,v.Warehouse,v.Farm);
    }
    if (input == "3")
    {
        v.WoodFactory.upgrade(v.BuildList, v.Warehouse,v.Farm);
    }
    if (input == "4")
    {
        v.ClayFactory.upgrade(v.BuildList, v.Warehouse,v.Farm);
    }

    if (input == "5")
    {
        v.Warehouse.PrintResources();
    }

    if(input == "6")
    {
        v.Warehouse.upgrade(v.BuildList, v.Warehouse,v.Farm);
    }
    if(input == "7")
    {
        v.BuildList.printItemsInList();
    }
    if(input == "8")
    {
        v.Farm.printFarmInfo();
    }

    displayOptions();
    input = Console.ReadLine();
}



void displayOptions(){
    Console.WriteLine("Chooose Option");
    Console.WriteLine("1) Print Buildings");
    Console.WriteLine("2) Upgrade IronFactory");
    Console.WriteLine("3) Upgrade WoodFactory");
    Console.WriteLine("4) Upgrade ClayFactory");
    Console.WriteLine("5) View Warehouse");
    Console.WriteLine("6) Upgrade Warehouse");
    Console.WriteLine("7) Print ConstructionList");
    Console.WriteLine("8) Print Farm Info");



}