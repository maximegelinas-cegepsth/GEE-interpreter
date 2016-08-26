using System;
using System.Collections.Generic;

namespace Interpreter.Commands
{
    public class AddRandomCommand : ICommand
    {
        public int? Parameter { get; set; }

        public Stack<int> Stack { get; set; }

        private readonly Random _generator = new Random();

        public void Execute()
        {
            if (Stack == null) throw new InvalidOperationException();

            Stack.Push(_generator.Next());
        }
    }
}
