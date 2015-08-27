using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroPlayerGame
{
    public interface IGameConfigurator
    {
        List<Robots.IRobot> GetRobots();

        GameField GetField();
    }
}
