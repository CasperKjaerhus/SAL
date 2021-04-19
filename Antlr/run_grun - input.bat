@echo off
java org.antlr.v4.Tool p4.g4 -o ./ParserGenGrun
cd ./ParserGenGrun
javac --release 8 *.java
grun p4 s -gui
PAUSE