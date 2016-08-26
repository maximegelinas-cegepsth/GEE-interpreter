using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.Commands
{
    public class ReadCommand : ICommand
    {
        public int? Parameter { get; set; }

        public Stack<int> Stack { get; set; }

        public void Execute()
        {
            if (Stack == null) throw new InvalidOperationException();

            var line = "";
            int number; 

            do
            {
                Console.Clear();
                Console.WriteLine("Enter input (number):");
                line = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(line) || !int.TryParse(line, out number));

            Stack.Push(number);
        }
    }
}
