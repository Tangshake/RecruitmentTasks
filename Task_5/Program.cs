using System.IO;
using Task_5.Importer;
using Task_5.Processor;

string path = "input.txt";

var instructions = new InstructionImporter().ImportFromFile(path);

var p80386SX = new Intel80386();
p80386SX.Process(instructions);


