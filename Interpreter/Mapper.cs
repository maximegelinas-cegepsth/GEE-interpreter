using System;
using System.Collections.Generic;
using Interpreter.Commands;

namespace Interpreter
{
    public class Mapper: IMapper
    {
        private readonly Dictionary<char, Type> _map = new Dictionary<char, Type>()
        {
            { 'P', typeof(AddCommand) },
            { 'p', typeof(RemoveCommand) },
            { 'd', typeof(DuplicateCommand) },
            { '+', typeof(SumCommand) }
        };

        public Type GetCommandType(char letter) => _map.ContainsKey(letter) ? _map[letter] : null;
    }
}