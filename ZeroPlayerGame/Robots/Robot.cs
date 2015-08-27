using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZeroPlayerGame.Robots
{
    public class Robot : IRobot
    {
        public event EventHandler<EventRobotArgument> MoveIsMaked;
        private readonly string _weaponModule;
        private readonly string _movementModule;
        private bool _isLive = true;
        public bool IsLive {
            get { return _isLive; }
        } 

        public Cell Position { get; set; }

        public Robot(string movementModule, string weaponModule)
        {
            _weaponModule = weaponModule;
            _movementModule = movementModule;
        }

        public void Move(Cell diractionCell)
        {
            if (IsLive)
            {
                //Chang position
                if (MoveIsMaked != null)
                    MoveIsMaked(this, new EventRobotArgument(String.Format("Moving {0}", _movementModule)));
                Position.Value = null;
                Position = diractionCell;
                Position.Value = this;
            }
        }

        public void Shoot(IRobot robot)
        {
            if (MoveIsMaked != null)
                MoveIsMaked(this, new EventRobotArgument(String.Format("Attacking with a {0}", _weaponModule)));
                robot.Hit(_weaponModule);
        }

        public void Hit(string weaponModule)
        {
            if (MoveIsMaked != null)
                MoveIsMaked(this, new EventRobotArgument(String.Format("Got hit by a {0}", weaponModule)));
            _isLive = false;
            Position.Value = null;
            Position = null;
        }

        public MovingDirection GetDiraction()
        {
            return (MovingDirection)new Random().Next(0, 3);
            
        }
    }

    public class EventRobotArgument : EventArgs
    {
        private readonly string _message;

        public string Message { get { return _message; } }

        public EventRobotArgument(string message)
        {
            _message = message;

        }
    }
}
