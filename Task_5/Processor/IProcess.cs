using Task_5.Model;

namespace Task_5.Processor;

public interface IProcess
{
    void Process(List<Instruction> instructions);
}