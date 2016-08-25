using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Interpreter
{
    public class Interpreter
    {
        private readonly Mapper _mapper = new Mapper();

        public IEnumerable<ICommand> GetCommands(string code, IMapper mapper)
        {
            var commands = new List<ICommand>();
            var matches = Regex.Matches(code, @"([a-zA-Z+\-])([0-9]*)");

            foreach (Match match in matches)
            {
                var cmdTxt = match.ToString();
                var cmdLetter = cmdTxt[0];
                dynamic cmdParam = null;
                var cmdType = mapper.GetCommandType(cmdLetter);

                if (cmdType == null) continue;

                if (cmdTxt.Length > 1)
                {
                    cmdParam = int.Parse(cmdTxt.Substring(1));
                }
                var cmd = (ICommand)Activator.CreateInstance(cmdType);
                cmd.Parameter = cmdParam;

                commands.Add(cmd);
            }

            return commands;
        }
    }
}
