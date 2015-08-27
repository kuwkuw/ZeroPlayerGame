using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeroPlayerGame.Robots;

namespace ZeroPlayerGame
{
    public class GameConfigurator: IGameConfigurator
    {
        public List<Robots.IRobot> GetRobots()
        {
            return new List<IRobot>
            {
                new Robot("on wheels", "rocket launcher"),
                new Robot("on legs", "jigsaw"),
                new Robot("that flies on balloons", "bombs"),
                new Robot("on tracks", "laser")
            };
        }

        public GameField GetField()
        {
            return new GameField(5);
        }
    }
}
