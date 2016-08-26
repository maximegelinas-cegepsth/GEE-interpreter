using System;
using System.Collections.Generic;
using System.Linq;

namespace Interpreter
{
    public class Program
    {
        private static readonly Interpreter Interpreter = new Interpreter();
        private static readonly Invoker Invoker = new Invoker();
        private static readonly Mapper Mapper = new Mapper();
        private static readonly Stack<int> Memory = new Stack<int>();

        private static void Main(string[] args)
        {        
            var line = "";

            while (string.IsNullOrEmpty(line) || line != "exit")
            {
                Console.Write("Write your program: \r\n> ");
                line = Console.ReadLine();

                Invoker.Commands = Interpreter.GetCommands(line, Mapper)
                .Select(c =>
                {
                    c.Stack = Memory;
                    return c;
                });

                if (!Invoker.Commands.Any()) continue;

                Invoker.ExecuteCommands();
                Memory.Clear();
            }
        }

        public static void DisplayMemoryGraph() => Console.WriteLine($"| {string.Join(" | ", Memory.Reverse())} |");
    }
}
