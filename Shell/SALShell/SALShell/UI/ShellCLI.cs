using System;
using System.Collections.Generic;
using System.Text;

namespace SALShell.UI
{
    class ShellCLI : IShellUI
    {
        public ShellCLI()
        {
            Done = false;
        }
        private bool Done { get; set; }
        public event ShellEvent CommandEntered;

        public void Start()
        {
            Console.WriteLine("Welcome to the SAL Compiler!\n");
            DisplayHelp();
            do
            {
                //TODO: Read input and carry out command
                Console.WriteLine("\n");
                Console.WriteLine("Waiting for input...\n");
                GetInput();
            } while (!Done);
        }


        public void Close()
        {
            Done = true;
        }
        private void GetInput()
        {
            CommandEntered?.Invoke(Console.ReadLine());
        }
        public void DisplayHistory()
        {
            throw new NotImplementedException();
        }

        public void DisplayChangeDirectory()
        {
            throw new NotImplementedException();
        }

        public void DisplayCompilation()
        {
            throw new NotImplementedException();
        }

        public void DisplayHelp()
        {
            throw new NotImplementedException();
        }
        public void DisplayGeneralError(string eMessage)
        {
            throw new NotImplementedException();
        }

        public void DisplayCommandNotFoundMessage(string commandStr)
        {
            throw new NotImplementedException();
        }
    }
}
