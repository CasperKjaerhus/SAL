using System;
using System.Collections.Generic;
using System.Text;
using SALShell.Core;
using SALShell.UI;

namespace SALShell.Command
{
    interface ICommand
    {
        public void Execute(string[] argStrings, IShellUI ui, ICore core);
    }
}
