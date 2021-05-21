using System;
using System.Diagnostics;
using System.IO;
using SALShell.Compiler.Parser;

namespace SALShell.Compiler.CodeGen
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
            CompileToMachineCode(path, name);
        }

        private void CompileToMachineCode(string path, string name)
        {
            string ExePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string DirectoryPath = System.IO.Path.GetDirectoryName(ExePath);
            string BoardName = "arduino:avr:uno";
            string fileCreationPath = $"{path}\\{name}.ino";

            Console.WriteLine(fileCreationPath);

            Process.Start($"{DirectoryPath}\\arduino-cli", $"compile --fqbn {BoardName} {fileCreationPath}");
        }
    }
}
