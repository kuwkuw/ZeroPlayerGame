using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroPlayerGame
{
    public class GameActionEventArgs
    {
        private string _message;
        public string Message {
            get { return _message; }
        }

        public GameActionEventArgs(string message)
        {
            _message = message;
        }
    }
}
