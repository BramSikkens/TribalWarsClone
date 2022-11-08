using TribalWarsCloneDomain.Models;
using TribalWarsCloneServer.Socket;
using TribalWarsCloneServer.Socket.Messages;

namespace TribalWarsCloneServer
{
    public sealed class Game:IObserver
    {

        private static Game instance = null;
        //Generate World
        public World world { get; private set; }
        protected Game()
        {
            SetupGame();
        }

        public static Game Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Game();
                }
                return instance;
            }
        }

        public void SetupGame()
        {
            world = new World();
        }


        //Dit moet ergens anders
        public void Update(SocketMessage message)
        {
            Console.WriteLine(message.message);
            if (message.message == "1")
            {
                Game.Instance.world.createNewVillage(message.from, "newvillage");
                Console.WriteLine("new Village Created");
            }
            if (message.message == "2")
            {
                Game.Instance.world.Villages[message.from].IronMine.Upgrade(Game.Instance.world.Villages[message.from].BuildList);
                Console.WriteLine("upgrade IronMine");
            }
            if (message.message == "3")
            {
                Game.Instance.world.Villages[message.from].TimberCamp.Upgrade(Game.Instance.world.Villages[message.from].BuildList);
                Console.WriteLine("upgrade TimberCamp");
            }
            if (message.message == "4")
            {
                Game.Instance.world.Villages[message.from].ClayPit.Upgrade(Game.Instance.world.Villages[message.from].BuildList);
                Console.WriteLine("upgrade ClayPit");
            }

        }

    }
}
