using Task_5.Model;

namespace Task_5.Processor;

public class Intel80386 : IProcess
{
    private float result = 0;

    public void Process(List<Instruction> instructions)
    {
        //Init value
        result = instructions.First(x => x.Command == CommandType.Apply).Value;
        
        foreach(var instruction in instructions)
        {
            ExecuteInstruction(instruction);
            Console.WriteLine($"{instruction.Command} {instruction.Value} Result: {result}");
        }
    }

    private void ExecuteInstruction(Instruction instruction)
    {
        switch(instruction.Command)
        {
            case CommandType.Add: result+=instruction.Value; break;
            case CommandType.Substract: result-=instruction.Value; break;
            case CommandType.Multiply: result*=instruction.Value; break;
            case CommandType.Divide: result/=instruction.Value; break;
            case CommandType.Apply: break;
        }
    }
}