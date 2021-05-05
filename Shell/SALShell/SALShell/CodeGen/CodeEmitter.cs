using SALShell.CodeGen;
using SALShell.Parser;
using SALShell.SymbolTable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SALShell.Core.CodeGeneration
{
    class CodeEmitter
    {
        private CodeGenVisitor CodeGenerationVisitor = new CodeGenVisitor();

        private void CreateFile(string filePath, string fileName, ASTNode root)
        {
            string fileCreationPath = $"{filePath}/{fileName}.ino";

            using (StreamWriter StreamW = File.CreateText(fileCreationPath))
            {
                StreamW.WriteLine("void setup() {");
                WriteToSetup(StreamW, root);
                StreamW.WriteLine("}");

                StreamW.WriteLine("void loop() {");
                //WriteToLoop(StreamW, root);
                StreamW.WriteLine("}");
            }

        }

        private void WriteToSetup(StreamWriter streamW, ASTNode node)
        {
            streamW.Write(CodeGenerationVisitor.Visit(node) + "\n");

            foreach (ASTNode child in node.Children)
            {
                WriteToSetup(streamW, child);
            }
        }

        private void WriteToLoop(StreamWriter streamW, ASTNode root)
        {
            throw new NotImplementedException();
        }

        public void SynthesizeCode(string path, string name, ASTNode ASTroot)
        {
            CreateFile(path, name, ASTroot);
        }



    }
}
