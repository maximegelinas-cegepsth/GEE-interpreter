using System;

namespace Interpreter
{
    public interface IMapper
    {
        Type GetCommandType(char letter);
    }
}