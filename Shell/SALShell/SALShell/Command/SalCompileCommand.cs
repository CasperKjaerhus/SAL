using System;
using System.Collections.Generic;
using System.Text;
using SALShell.Core;
using SALShell.UI;
using System.IO;

namespace SALShell.Command
{
    class SalCompileCommand : ICommand
    {
        public void Execute(string[] argStrings, IShellUI ui, ICore core)
        {
            string Path = argStrings[1];

            try
            {
                core.OpenFile(Path);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
