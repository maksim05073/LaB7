namespace LB7.Task2;

public class Balloon:Devices
{ 
    public Balloon(string name, double weight, bool isElectronic) : base("Balloon", 0, false)
    {
        Name = name;
        Weight = weight;
        IsElectronic = isElectronic;

    }

    
    
    
}