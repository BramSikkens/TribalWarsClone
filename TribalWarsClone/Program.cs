// See https://aka.ms/new-console-template for more information




using TribalWarsClone.Models;

Village v = new Village();
BuildList b = new BuildList();



string input = Console.ReadLine();


while (input != "exit")
{
    if(input == "1")
    {
        v.IronFactory.upgrade(b);
    }
    Console.ReadLine();
}
    