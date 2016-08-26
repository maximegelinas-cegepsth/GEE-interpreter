using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.Commands
{
    public class ReadTextCommand : ICommand
    {
        public int? Parameter { get; set; }

        public Stack<int> Stack { get; set; }

        public void Execute()
        {
            if (Stack == null) throw new InvalidOperationException();

            var line = "";

            do
            {
                line = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(line));

            var asciiLine = Encoding.ASCII.GetBytes(line);

            foreach (var asciiChar in asciiLine.Reverse())
            {
                Stack.Push(asciiChar);
            }

            Stack.Push(asciiLine.Length);
        }
    }
}
