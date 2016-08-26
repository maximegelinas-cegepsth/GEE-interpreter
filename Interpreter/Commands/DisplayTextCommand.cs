using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.Commands
{
    public class DisplayTextCommand : ICommand
    {
        public int? Parameter { get; set; }

        public Stack<int> Stack { get; set; }

        public void Execute()
        {
            if (Stack == null) throw new InvalidOperationException();

            var line = "";
            var counter = Stack.Pop();

            while (counter > 0)
            {
                line += (char) Stack.Pop();
                counter--;
            }

            Console.WriteLine(line);
        }
    }
}
