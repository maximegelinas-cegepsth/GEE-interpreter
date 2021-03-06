﻿using System;
using System.Collections.Generic;

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
                line = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(line) || !int.TryParse(line, out number));

            Stack.Push(number);
        }
    }
}
