using TribalWarsCloneDomain.Models;
using TribalWarsCloneServer.Socket;
using TribalWarsCloneServer.Socket.Messages;

Game newGame = new Game();

//Setup Socket Server
TcpSocketServer TcpSocketServer = new TcpSocketServer();
TcpSocketServer.StartServer(443);
TcpSocketServer.Listen(newGame);


public class Game:IObserver
{
    //Generate World
    World world = new World();

   

    public void Update(SocketMessage message)
    {
        Console.WriteLine(message.message);
        if(message.message == "1")
        {
            world.createNewVillage(message.from, "newvillage");
            Console.WriteLine("new Village Created"); 
        }
        if (message.message == "2")
        {
            world.Villages[message.from].IronMine.Upgrade(world.Villages[message.from].BuildList);
            Console.WriteLine("upgrade IronMine");
        }
        if (message.message == "3")
        {
            world.Villages[message.from].TimberCamp.Upgrade(world.Villages[message.from].BuildList);
            Console.WriteLine("upgrade TimberCamp");
        }
        if (message.message == "4")
        {
            world.Villages[message.from].ClayPit.Upgrade(world.Villages[message.from].BuildList);
            Console.WriteLine("upgrade ClayPit");
        }

    }
}



