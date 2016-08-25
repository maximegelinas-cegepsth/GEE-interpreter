using System.Collections.Generic;

namespace Interpreter
{
    public interface ICommand
    {
        int? Parameter { get; set; }

        Stack<int> Stack { get; set; }

        void Execute();
    }
}
