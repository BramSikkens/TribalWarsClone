// See https://aka.ms/new-console-template for more information






using TribalWarsCloneDomain.Models.Buildings;
using TribalWarsCloneDomain.Models;


Village v = new Village();

Console.WriteLine("1) Print Buildings");
Console.WriteLine("2) Upgrade IronFactory");
Console.WriteLine("3) Upgrade WoodFactory");
Console.WriteLine("4) Upgrade ClayFactory");
Console.WriteLine("5) View Warehouse");

string input = Console.ReadLine();



while (input != "exit")
{

    if(input == "1")
    {
        v.printBuildings();
    }
    if (input == "2")
    {
        v.IronFactory.upgrade(v.BuildList,v.Warehouse);
    }
    if (input == "3")
    {
        v.WoodFactory.upgrade(v.BuildList, v.Warehouse);
    }
    if (input == "4")
    {
        v.ClayFactory.upgrade(v.BuildList, v.Warehouse);
    }
    if (input == "5")
    {
        v.Warehouse.print();
    }
    input = Console.ReadLine();
}
    