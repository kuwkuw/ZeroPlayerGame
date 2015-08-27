using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ZeroPlayerGame
{
    public class GameField
    {
        private readonly Cell[,] _fildCells;


        public GameField(int silze)
        {
            _fildCells=new Cell[silze,silze];
            for (int i = 0; i < silze; i++)
            {
                for (int j = 0; j < silze; j++)
                {
                    _fildCells[i,j]= new Cell(i,j);
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            return _fildCells[x, y];
        }
        public Cell GetCell(int x, int y, MovingDirection direction)
        {
            Cell cell = null;
            
            switch (direction)
            {
                case MovingDirection.Up:
                    cell = _fildCells[x, --y];
                    break;
                case MovingDirection.Down:
                    cell = _fildCells[x, ++y];
                    break;
                case MovingDirection.Left:
                    cell = _fildCells[--x, y];
                    break;
                case MovingDirection.Right:
                    cell = _fildCells[++x, y];
                    break;
            }
            return cell;
        }
    }
}
