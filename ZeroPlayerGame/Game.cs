using System;
using System.Collections.Generic;
using ZeroPlayerGame.Robots;

namespace ZeroPlayerGame
{
    public class Game
    {
        private event EventHandler<GameActionEventArgs> IsStarted;
        private event EventHandler<GameActionEventArgs> IsMoveEnded;
        private List<IRobot> _robots;
        private GameField _field;

        public Game(IGameConfigurator congigurator, IGameView view)
        {
            IsStarted += view.GameAction;
            IsMoveEnded += view.MoveAction;
            _robots = congigurator.GetRobots();
            _field = congigurator.GetField();
            foreach (var robot in _robots)
            {
                robot.MoveIsMaked += view.RobotAction;
            }
        }

        public Game(GameField field, List<IRobot> robots)
        {
            _field = field;
            _robots = robots;
        }

        /// <summary>
        /// Start the game.
        /// </summary>
        public void StartGame()
        {
            if (IsStarted!=null)
                IsStarted(this, new GameActionEventArgs("Game is started."));
            
            // arrang robots on game fiald in random cells
            PutsRobotsOnField();

            while (IsCanPlay())
            {
                MakeMoves();
            }

        }
        /// <summary>
        /// Make robots moves
        /// </summary>
        private void MakeMoves()
        {
            foreach (var robot in _robots)
            {
                if (robot.IsLive)
                {
                    //get diraction
                    MovingDirection diraction = robot.GetDiraction();
                    while (DiractionNoValid(diraction, robot.Position))
                    {
                        diraction = robot.GetDiraction();
                    }
                    var diractionCell = _field.GetCell(robot.Position.X, robot.Position.Y, diraction);
                    //check diration cell
                    if (diractionCell.Value == null)
                    {
                        robot.Move(diractionCell);
                    }
                    else
                    {
                        robot.Shoot(diractionCell.Value);
                    }
                }
            }
            if(IsMoveEnded!=null)
                IsMoveEnded(this, new GameActionEventArgs("Move ended."));
        }

        private bool DiractionNoValid(MovingDirection daraction, Cell cell)
        {
            int x = cell.X;
            int y = cell.Y;

            switch (daraction)
            {
                case MovingDirection.Up:
                    y--;
                    break;
                case MovingDirection.Right:
                    x++;
                    break;
                case MovingDirection.Down:
                    y++;
                    break;
                case  MovingDirection.Left:
                    x--;
                    break;

            }
            if(x>4||y>4||x<0||y<0)
                return true;

            return false;
        }

        /// <summary>
        /// Check for game can continue
        /// </summary>
        /// <returns></returns>
        private bool IsCanPlay()
        {
            if(_robots.Count>1)
                return true;

            return false;
        }

        /// <summary>
        /// Puts robots on field in random places
        /// </summary>
        private void PutsRobotsOnField()
        {
            var r = new Random();
            foreach (var robot in _robots)
            {
                var cell = _field.GetCell(r.Next(3), r.Next(3));
                while (cell.Value!=null)
                {
                    cell = _field.GetCell(r.Next(3), r.Next(3));
                }
                cell.PutRobotOnCell(robot);
            }
        }
    }
}
