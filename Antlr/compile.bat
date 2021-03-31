@echo off
@RD /S /Q "./Test_Parser_src/Test_Parser/ParserGen"
java org.antlr.v4.Tool p4.g4 -o ./Test_Parser_src/Test_Parser/ParserGen -Dlanguage=CSharp
dotnet build ./Test_Parser_src/Test_Parser -o ./Test_Parser
PAUSE