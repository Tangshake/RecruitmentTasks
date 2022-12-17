using Task_5.Model;

namespace Task_5.Importer;
public class InstructionImporter : IImport
{
    public List<IInstruction> ImportFromFile(string filePath)
    {
        if (!System.IO.File.Exists(filePath))
            throw new FileNotFoundException();

        var fileContent = System.IO.File.ReadAllLines(filePath);

        var instructions = new List<IInstruction>();

        foreach(string ins in fileContent)
        {
            instructions.Add(Parse(ins));
        }

        return instructions;
    }

    private Instruction Parse(string lineOfText)
    {
        var values = lineOfText.Split(' ');
        
        Enum.TryParse(values[0], true, out CommandType command);
        Int32.TryParse(values[1], out Int32 value);

        return new Instruction() { Command = command, Value = value };
    }
}