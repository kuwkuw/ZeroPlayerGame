using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeroPlayerGame.Robots;

namespace ZeroPlayerGame
{
    public class GameView : IGameView
    {
        public void RobotAction(object sender, EventRobotArgument e)
        {
            Console.WriteLine(e.Message);
        }


        public void GameAction(object sender, GameActionEventArgs e)
        {
            Console.WriteLine(e.Message);
        }


        public void MoveAction(object sender, GameActionEventArgs e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Press any key for next move");
            Console.ReadLine();
        }
    }
}
