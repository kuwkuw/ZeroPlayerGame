using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroPlayerGame.Robots
{
    public interface IRobot
    {
        Cell Position { get; set; }
        bool IsLive { get; } 
        event EventHandler<EventRobotArgument> MoveIsMaked;
        void Move(Cell diractionCell);
        void Shoot(IRobot robot);
        void Hit(string weaponModule);
        MovingDirection GetDiraction();
    }
}
