using Task_5.Model;

namespace Task_5.Importer;

public interface IImport
{
    public List<IInstruction> ImportFromFile(string filePath);
}