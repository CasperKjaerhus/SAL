using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using SALShell.Core;
using SALShell.UI;

namespace SALShell.Command
{
    class ExitCommand :ICommand
    {
        public void Execute(string[] argStrings, IShellUI ui, ICore core)
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
