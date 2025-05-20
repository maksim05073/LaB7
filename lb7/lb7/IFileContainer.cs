namespace lb7;

public interface IFileContainer
{
    void Save(string fileName);
    void Load(string fileName);
    bool IsDataSaved { get; }
}