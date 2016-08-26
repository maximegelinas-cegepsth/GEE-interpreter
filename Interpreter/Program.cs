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
            Invoker.Commands = Interpreter.GetCommands("rw", Mapper)
                .Select(c =>
                {
                    c.Stack = Memory;
                    return c;
                });

            Invoker.ExecuteCommands();

            DisplayMemoryGraph();

            Console.ReadKey();
        }

        public static void DisplayMemoryGraph() => Console.WriteLine($"| {string.Join(" | ", Memory)} |");
    }
}
