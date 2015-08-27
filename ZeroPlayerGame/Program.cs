using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroPlayerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            IGameView gameView = new GameView();
            IGameConfigurator configurator = new GameConfigurator();
            var game = new Game(configurator, gameView);
            game.StartGame();
        }

        
    }
}
