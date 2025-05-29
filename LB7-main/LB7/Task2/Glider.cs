namespace LB7.Task2;

public class Glider: Devices
{
    public Glider(string name, double weight, bool isElectronic) : base("Glider", 0, false)
    {
        Name = name;
        Weight = weight;
        IsElectronic = isElectronic;

    }

}