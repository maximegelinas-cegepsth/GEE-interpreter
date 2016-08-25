using System;
using System.Collections.Generic;

namespace Interpreter.Commands
{
    public class AddCommand : ICommand
    {
        public int? Parameter { get; set; }

        public Stack<int> Stack { get; set; }

        public void Execute()
        {
            if (Stack == null || Parameter == null) throw new InvalidOperationException();

           Stack.Push(Parameter.Value);
        }
    }
}
