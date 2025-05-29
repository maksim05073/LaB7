namespace LB7.Task2;

public class Helicopter: Devices,IEngine
{
    public double EnginePower { get; set; }
    public string FuelType { get; set; }

    public Helicopter(string name, double weight, double power, string fuel)
        : base(name, weight, true)
    {
        EnginePower = power;
        FuelType = fuel;
    }
    public object Cl0oneTo()
    {
        return new Helicopter(Name, Weight, EnginePower, FuelType);
    }

    public override string ToString()
    {
        return $"Літак: {base.ToString()}, Потужність: {EnginePower} к.с., Паливо: {FuelType}";
    }
}