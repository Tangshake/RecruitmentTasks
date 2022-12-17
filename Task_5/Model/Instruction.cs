namespace Task_5.Model;

public class Instruction :IInstruction {
    public CommandType Command { get; set; }
    public int Value { get; set; }
}

public enum CommandType
{
    Add,
    Multiply,
    Divide,
    Substract,
    Apply
}