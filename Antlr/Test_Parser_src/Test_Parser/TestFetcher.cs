using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Test_Parser
{
    class TestFetcher
    {
        private readonly string _fileLocation;
        public TestFetcher(string location)
        {
            _fileLocation = location;
        }

        public List<Test> GetTests()
        {
            List<string> files = Directory.GetFiles(_fileLocation).Where(r => r.EndsWith(".txt")).ToList();
            List<Test> FileContents = new List<Test>();

            foreach (string file in files)
            {
                StreamReader sr = new StreamReader(file);
                string result = sr.ReadToEnd();

                FileContents.Add(new Test(file, result));
            }

            return FileContents;
        }
    }
}
