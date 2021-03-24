@echo off
@RD /S /Q "./ParseGen"
java org.antlr.v4.Tool p4.g4 -o ./ParseGen
javac --release 8 ./ParseGen/*.java
cd ./ParseGen
grun p4 s -gui
PAUSE