namespace Task_5.Model;

public interface IInstruction
{
    CommandType Command { get; set; }
    int Value { get; set; }
}