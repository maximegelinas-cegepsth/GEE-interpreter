using System;
using System.Collections.Generic;

namespace Interpreter.Commands
{
    public class RemoveCommand : ICommand
    {
        public int? Parameter { get; set; }

        public Stack<int> Stack { get; set; }

        public void Execute()
        {
            if (Stack == null) throw new InvalidOperationException();

            Stack.Pop();
        }
    }
}
