using System;

namespace Interpreter.Commands
{
    public class AddNumberCommand : ICommand
    {
        public int Number { get; set; }

        public AddNumberCommand(string[] args)
        {
            int number;

            if (!int.TryParse(args[0], out number))
            {
                throw new ArgumentException();
            }

            Number = number;
        }

        public void Execute()
        {
        }
    }
}
