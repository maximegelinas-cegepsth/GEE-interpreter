using System;
using System.Collections.Generic;
using Interpreter.Commands;

namespace Interpreter
{
    public class CommandsMapper
    {
        private readonly Dictionary<char, Type> _map = new Dictionary<char, Type>()
        {
            { 'P', typeof(AddNumberCommand) }
        };

        public Type GetCommandType(char letter) 
            => _map[letter] != null ? _map[letter] : null;
    }
}