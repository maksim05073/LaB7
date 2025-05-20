namespace lb7;

public interface IContainer<T>
{
    int Count { get; }
    T this[int index] { get; set; }
    void Add(T element);
    void Delete(T element);
}