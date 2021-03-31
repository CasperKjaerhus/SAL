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
            Console.WriteLine(Environment.CurrentDirectory);
        }

        public void DisplayCompilation()
        {
            throw new NotImplementedException();
        }

        public void DisplayHelp()
        {
            string helpL = "'-h' | '-help' | 'help' | 'h'";
            string helpR = "Display this menu.";

            string cdL = "'cd' <path>";
            string cdR ="Change directory to <path>.";

            string cdupL = "'..'";
            string cdupR = "Go up one directory.";

            string salcL = "'salc' <file>";
            string salcR = "Compile a <file> with the SAL Compiler.";

            Console.WriteLine("Welcome to the SAL Compiler!");
            Console.WriteLine("{0, -40} | {1, 10}", helpL, helpR);
            Console.WriteLine("{0, -40} | {1, 10}", cdL, cdR);
            Console.WriteLine("{0, -40} | {1, 10}", cdupL, cdupR);
            Console.WriteLine("{0, -40} | {1, 10}", salcL, salcR);
        }
        public void DisplayGeneralError(string eMessage)
        {
            throw new NotImplementedException();
        }

        public void DisplayCommandNotFoundMessage(string commandStr)
        {
            Console.WriteLine($"Sorry, I do not recognize the '{commandStr}' command. Try again.");
        }
    }
}
