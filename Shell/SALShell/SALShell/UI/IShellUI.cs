using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.UI
{
    delegate void ShellEvent(string command);

    interface IShellUI
    {
        void Start();
        void Close();
        void DisplayHistory();
        void DisplayChangeDirectory();
        void DisplayCompilation();
        void DisplayHelp();
        public event ShellEvent CommandEntered;
        void DisplayGeneralError(string eMessage);
        void DisplayCommandNotFoundMessage(string commandStr);
    }
}
