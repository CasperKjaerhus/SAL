using System;
using System.Collections.Generic;
using System.Text;
using SALShell.Core;
using SALShell.UI;
using System.IO;
using SALShell.Compiler.Compilation;

namespace SALShell.Command
{
    class SalCompileCommand : ICommand
    {
        public void Execute(string[] argStrings, IShellUI ui, ICore core)
        {
            try
            {
                string sourcePath = argStrings[1];
                string outputPath = argStrings[2];
                string fileName = argStrings[3];
                Compilation compilation = new Compilation(sourcePath, outputPath, fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Compilation Error\n");
                Console.WriteLine(e);
                Console.WriteLine("Please try again! type -h for help.\n");
            }
        }
    }
}
