using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Interpreter
{
    public class Interpreter
    {
        private readonly CommandsMapper _mapper = new CommandsMapper();

        public IEnumerable<ICommand> GetCommands(string code)
        {
            var matches = Regex.Matches(code, @"[a-zA-Z+\-][0-9]*");

            var commands = (
                from Match match in matches
                let commandTxt = match.ToString()
                let letter = commandTxt[0]
                let args = new object[] { new[] { commandTxt.Substring(1) } }
                let commandType = _mapper.GetCommandType(letter)
                where commandType != null
                select (ICommand) Activator.CreateInstance(commandType, args));

            return commands.ToArray();
        }
    }
}
