namespace lb7_2;

public class Helicopter : Devices, IEngine
{
    public double EnginePower { get; set; }
    public string FuelType { get; set; }

    public Helicopter(string name, double weight, double power, string fuel)
        : base(name, weight, true)
    {
        EnginePower = power;
        FuelType = fuel;
    }

    public object CloneTo()
    {
        return new Helicopter(Name, Weight, EnginePower, FuelType);
    }

    public override string ToString()
    {
        return $"Вертоліт: {base.ToString()}, Потужність: {EnginePower} к.с., Паливо: {FuelType}";
    }
}