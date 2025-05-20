namespace lb7;

public class Modul : IComparable<Modul>, ICloneable
{
    public Person Manager { get; set; }
    public string NameModul { get; set; }
    public double SizeModul { get; set; }

    public Modul() { }

    public Modul(Person manager, string name, double size)
    {
        Manager = manager;
        NameModul = name;
        SizeModul = size;
    }

    public override string ToString() =>
        $"Manager: {Manager.ToShortString()}, Name: {NameModul}, Size: {SizeModul}";

    public int CompareTo(Modul? other)
    {
        if (other == null) return 1;
        return SizeModul.CompareTo(other.SizeModul);
    }

    public object Clone() =>
        new Modul((Person)Manager.Clone(), NameModul, SizeModul);
}