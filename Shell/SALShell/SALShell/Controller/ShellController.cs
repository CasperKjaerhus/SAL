using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SALShell.Command;
using SALShell.Core;
using SALShell.UI;

namespace SALShell.Controller
{
    class ShellController
    {
        public ShellController(IShellUI ui, ICore core)
        {
            Ui = ui;
            Core = core;
            ui.CommandEntered += Ui_CommandEntered;
        }

        private Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>()
        {
            {"help", new HelpCommand()},
            {"-help", new HelpCommand()},
            { "-h", new HelpCommand()},
            { "h", new HelpCommand()},
            {"cd", new ChangeDirectoryCommand()},
            {"salc", new SalCompileCommand()},
        };

        private void Ui_CommandEntered(string command)
        {
            try
            {
                ParseCommand(command);
            }
            catch (Exception e)
            {
                Ui.DisplayGeneralError(e.Message);
            }
        }

        private void ParseCommand(string input)
        {
            string[] argStrings = input.Trim().Split(" ");
            string commandStr = argStrings[0];
            try
            {
                if (commands.ContainsKey(commandStr))
                {
                    ICommand command = commands[commandStr];
                    command.Execute(argStrings, Ui, Core);
                }
                else
                    Ui.DisplayCommandNotFoundMessage(commandStr);
            }
            catch (Exception e) //TODO: Add exception handling
            {
                throw new NotImplementedException();
            }
        }

        public ICore Core { get; set; }

        public IShellUI Ui { get; set; }
    }
}
