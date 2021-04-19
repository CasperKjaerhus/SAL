using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SALShell.Core.CodeGeneration
{
    class CodeEmitter
    {
        private void CreateFile(string filePath, string fileName)
        {
            string fileCreationPath = $"{filePath}/{fileName}.ino";

            using (StreamWriter StreamW = File.CreateText(fileCreationPath))
            {
                StreamW.WriteLine("void setup() {");
                WriteToSetup(StreamW);
                StreamW.WriteLine("}");

                StreamW.WriteLine("void loop() {");
                WriteToLoop(StreamW);
                StreamW.WriteLine("}");
            }

        }

        private void WriteToSetup(StreamWriter streamW)
        {
            throw new NotImplementedException();
        }

        private void WriteToLoop(StreamWriter streamW)
        {
            throw new NotImplementedException();
        }

        private void ForLoopEmitter(StreamWriter streamW, int iValue, string varInit, string boolOp, string boolOpValue, int stepValue, string ForLoopBody)
        {
            streamW.WriteLine($"for (int {varInit} = {iValue}; {varInit} {boolOp} {boolOpValue}; {varInit}+{stepValue})");
            streamW.WriteLine("{");
            streamW.WriteLine($"{ForLoopBody}");
            streamW.WriteLine("}");

        }

        private void SwitchEmitter(StreamWriter streamW, string expression, string caseOp, string caseBody, string defaultBody)
        {
            streamW.WriteLine($"switch ({expression})");
            streamW.WriteLine("{");
            streamW.WriteLine($"case {caseOp}:");
            streamW.WriteLine($"{caseBody}");
            streamW.WriteLine($"break;");
            streamW.WriteLine($"default:");
            streamW.WriteLine($"{defaultBody}");
            streamW.WriteLine("}");

        }

        private void WhileEmitter(StreamWriter streamW, string boolexpression, string WhileBody)
        {
            streamW.WriteLine($"while ({boolexpression})");
            streamW.WriteLine("{");
            streamW.WriteLine($"{WhileBody}");
            streamW.WriteLine("}");
        }
        
        private void ForeachEmitter(StreamWriter streamW, int numberOfElements, string ArrayName, string ForEachBody)
        {
            streamW.WriteLine($"for (int {numberOfElements} : {ArrayName})");
            streamW.WriteLine("{");
            streamW.WriteLine($"{ForEachBody}");
            streamW.WriteLine("}");
        }

        private void IfEmitter(StreamWriter streamW, string boolexpression, string IfBody)
        {
            streamW.WriteLine($"if ({boolexpression})");
            streamW.WriteLine("{");
            streamW.WriteLine($"{IfBody}");
            streamW.WriteLine("}");
        }

        private void ElseIfEmitter(StreamWriter streamW, string boolexpression, string IfBody, string ElseIfBody, string elseBoolexpression)
        {
            streamW.WriteLine($"else if ({elseBoolexpression})");
            streamW.WriteLine("{");
            streamW.WriteLine($"{ElseIfBody}");
            streamW.WriteLine("}");
        }

        private void ElseEmitter(StreamWriter streamW, string boolexpression, string IfBody, string ElseBody)
        {
            streamW.WriteLine($"else");
            streamW.WriteLine("{");
            streamW.WriteLine($"{ElseBody}");
            streamW.WriteLine("}");
        }

        private void VariableDeclEmitter(StreamWriter streamW, string varType, string VarName, string VarValue)
        {
            streamW.WriteLine($"{varType} {VarName} = {VarValue}");
        }

        private void VoidFunctionDeclEmitter(StreamWriter streamW, string functionId, string funcParams, string funcBody)
        {
            streamW.WriteLine($"void {functionId}({funcParams})");
            streamW.WriteLine("{");
            streamW.WriteLine($"{funcBody}");
            streamW.WriteLine("}");
        }

        private void FunctionDeclEmitter(StreamWriter streamW, string returnType, string returnVal, string functionId, string funcParams, string funcBody)
        {
            streamW.WriteLine($"{returnType} {functionId}({funcParams})");
            streamW.WriteLine("{");
            streamW.WriteLine($"{funcBody}");
            streamW.WriteLine($"return {returnVal};");
            streamW.WriteLine("}");
        }
    }
}
