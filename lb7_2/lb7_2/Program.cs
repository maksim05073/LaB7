namespace lb7_2;

public class Program
{
    public static void Main(string[] args)
    {
        Register registry = new Register();
        registry.AddDevice(new Plane("Boeing 737", 41000, 27000, "Jet A1"));
        registry.AddDevice(new Helicopter("Apache", 5000, 1800, "Kerosene"));
        registry.AddDevice(new Glider("ASW-27", 450, false));
        registry.AddDevice(new Balloon("SkyBall", 300, false));
        registry.AddDevice(new FlyingCarpet("AladdinCarpet", 50, false));
        registry.AddDevice(new Plane("Boeing 737", 42000, 28000, "Jet A1"));
        Console.WriteLine("=== УСЕ ОБЛАДНАННЯ ===");
        registry.PrintAll();
        Console.WriteLine("\n=== ЕЛЕКТРОННЕ ОБЛАДНАННЯ ===");
        registry.PrintElectronic();
        Console.WriteLine("\n=== ОБЛАДНАННЯ БЕЗ ДВИГУНІВ ===");
        registry.PrintNoEngine();
        Console.WriteLine("\n=== СОРТУВАННЯ ===");
        registry.RequestAndSort();
        Console.WriteLine("\n=== ПІСЛЯ СОРТУВАННЯ ===");
        registry.PrintAll();
        Console.ReadKey();
    }
}
