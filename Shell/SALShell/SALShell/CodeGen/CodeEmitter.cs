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
        private InoResolveVisitor Resolver = new InoResolveVisitor();
        private CodeGenVisitor CodeGenerationVisitor = new CodeGenVisitor();

        private void CreateFile(string filePath, string fileName, ASTNode root)
        {
            string fileCreationPath = $"{filePath}/{fileName}.ino";

            using (StreamWriter StreamW = File.CreateText(fileCreationPath))
            {
                WriteToGlobal(StreamW, root);

                StreamW.WriteLine("void loop()\n{");
                WriteToLoop(StreamW, root);
                StreamW.WriteLine("}");
            }

        }
        private void WriteToGlobal(StreamWriter streamW, ASTNode node)
        {
            CodeGenerationVisitor.IsGlobal = true;
            string Code = CodeGenerationVisitor.Visit(node);
            CodeGenerationVisitor.IsGlobal = false;
            streamW.Write(CodeGenerationVisitor.GlobalVariables + "\n");
            streamW.Write(Code);
            if (!(CodeGenerationVisitor.HasSetup))
            {
                streamW.WriteLine("void setup(){\n");
                streamW.WriteLine("}\n");
            }
        }

        private void WriteToLoop(StreamWriter streamW, ASTNode node)
        {
            CodeGenerationVisitor.IsLoop = true;
            streamW.Write(CodeGenerationVisitor.Visit(node));
            CodeGenerationVisitor.IsLoop = false;
        }

        public void GenerateCode(string path, string name, ASTNode ASTroot)
        {
            Resolver.PopulateAST(ASTroot);
            CreateFile(path, name, ASTroot);
        }
    }
}
