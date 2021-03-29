using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Parser
{
    class TestRunner
    {
        private ICollection<Test> Tests;
        public TestRunner(ICollection<Test> tests)
        {
            Tests = tests;
        }

        public void RunTests()
        {
            foreach(Test test in Tests)
            {
                P4ParserErrorListener p4ParserErrorListener = new P4ParserErrorListener(test.Name);
                P4Parser parser = new P4Parser(test.Content, p4ParserErrorListener);

                p4ParserErrorListener.HandleErrors();
            }
        }
    }
}
