namespace LB7.Task2;

public class Plane: Devices, IDevice,IEngine
{
    public double EnginePower { get; set; }
    public string FuelType { get; set; }

    public Plane(string name, double weight, double power, string fuel)
        : base(name, weight, true)
    {
        EnginePower = power;
        FuelType = fuel;
    }

    public object CloneTo()
    {
        return new Plane(Name, Weight, EnginePower, FuelType);
    }

    public override string ToString()
    {
        return $"Літак: {base.ToString()}, Потужність: {EnginePower} к.с., Паливо: {FuelType}";
    }
}