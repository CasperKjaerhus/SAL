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
            try
            {
                Compilation compilation = new Compilation(argStrings[1]);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
