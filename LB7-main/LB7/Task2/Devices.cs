namespace LB7.Task2;

public class Devices : IDevice, ICloneable, IComparable<Devices>
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public bool IsElectronic { get; set; }

    public Devices(string name, double weight, bool isElectronic)
    {
        Name = name;
        Weight = weight;
        IsElectronic = isElectronic;
    }

    public int CompareTo(Devices? other)
    {
        if (other == null) return 1;
        return Name.CompareTo(other.Name);
    }

    public override string ToString()
    {
        return $"{Name}, Вага: {Weight} кг, Електронний: {IsElectronic}";
    }

    public object CloneTo()
    {
        return new Devices(Name, Weight, IsElectronic);
    }
}