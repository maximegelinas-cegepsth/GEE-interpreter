using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Interpreter
{
    public class Invoker
    {
        public IEnumerable<ICommand> Commands { get; set; }

        public void ExecuteCommands()
        {
            foreach (var command in Commands)
            {
                command.Execute();
            }
        }
    }
}