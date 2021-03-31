using System;
using System.Collections.Generic;
using System.Text;
using SALShell.Core;
using SALShell.UI;

namespace SALShell.Command
{
    class ChangeDirectoryCommand : ICommand
    {
        public void Execute(string[] argStrings, IShellUI ui, ICore core)
        {
            string path = argStrings[1];

            try
            {
                if (path != null)
                {
                    core.ChangeDirectory(path);
                    ui.DisplayChangeDirectory();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
