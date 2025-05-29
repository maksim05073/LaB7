namespace LB7.Task2;

public class Register: Devices,IComparable<Devices>
{
    public Register (string name, double weight, bool isElectronic) : base("Register", 0, false)
    {
        Name = name;
        Weight = weight;
        IsElectronic = isElectronic;

    }
    public class NameComparer : IComparer<Devices>
    {
        public int Compare(Devices x, Devices y)
        {
            return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }
    public class WeightComparer : IComparer<Devices>
    {
        public int Compare(Devices x, Devices y)
        {
            return x.Weight.CompareTo(y.Weight);
        }
    }

}