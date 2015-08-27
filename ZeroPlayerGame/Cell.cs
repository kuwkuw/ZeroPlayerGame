using ZeroPlayerGame.Robots;

namespace ZeroPlayerGame
{
    public class Cell
    {
        public IRobot Value { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
        internal void PutRobotOnCell(IRobot robot)
        {
            robot.Position = this;
            Value = robot;
        }
    }
}
