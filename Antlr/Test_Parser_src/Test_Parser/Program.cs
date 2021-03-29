using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.IO;
using System.Text;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace Test_Parser
{
    class Program
    {
        static void Main()
        {
            List<Test> tests = new TestFetcher("./Tests").GetTests();
            TestRunner runner = new TestRunner(tests);

            runner.RunTests();
            
        }
    }
}
