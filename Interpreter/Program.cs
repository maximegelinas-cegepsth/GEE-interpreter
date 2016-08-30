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

                // Gets the commands.
                Invoker.Commands = Interpreter.GetCommands(line, Mapper)
                .Select(c =>
                {
                    // Sets memory context of the commands.
                    c.Stack = Memory;
                    return c;
                });

                // If some commands are found.
                if (!Invoker.Commands.Any())
                {
                    Console.Write("No command found. \r\n\r\n");
                    continue;
                }

                try
                {
                    // Executes each commands.
                    Invoker.ExecuteCommands();
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid program.");
                }

                Memory.Clear();
                Console.WriteLine();
            }
        }

        public static void DisplayMemoryGraph() => Console.WriteLine($"| {string.Join(" | ", Memory.Reverse())} |");
    }
}
