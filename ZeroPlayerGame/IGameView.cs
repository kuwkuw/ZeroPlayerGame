using ZeroPlayerGame.Robots;

namespace ZeroPlayerGame
{
    public interface IGameView
    {
        void RobotAction(object o, EventRobotArgument arg);
        void GameAction(object sender, GameActionEventArgs e);
        void MoveAction(object sender, GameActionEventArgs e);
    }
}
