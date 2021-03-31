using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SALShell.Core
{
    class Core : ICore
    {
        public void OpenFile(string fileLoc)
        {

            if (Path.GetExtension(fileLoc) == ".sal")
            {
                using (var streamReader = new StreamReader(fileLoc))
                {
                    string SourceProgram = streamReader.ReadToEnd();
                    Console.WriteLine("This is in the file: " + SourceProgram);
                }
            }
            else 
            {
                throw new FileNotFoundException();
            }
            

        }

        public void ChangeDirectory(string path)
        {
            if(path != null)
            {
                Environment.CurrentDirectory = path;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
