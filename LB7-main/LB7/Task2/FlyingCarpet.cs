namespace LB7.Task2;

public class FlyingCarpet: Devices
{
    public FlyingCarpet(string name, double weight, bool isElectronic) : base("FlyingCarpet", 0, false)
    {
        Name = name;
        Weight = weight;
        IsElectronic = isElectronic;

    }
}