namespace lb7;
public enum ProjectType
{
    Commercial,
    Training,
    PersonalUse
}

public class Project : ICloneable
{
    public string Name { get; set; }
    public ProjectType Type { get; set; }
    public DateTime EndDate { get; set; }
    public double Price { get; set; }
    public Modul[] Modules { get; set; }

    public Project(string name, ProjectType type, DateTime endDate, double price, Modul[] modules)
    {
        Name = name ?? "Unnamed";
        Type = type;
        EndDate = endDate;
        Price = price >= 0 ? price : throw new ArgumentException("Price cannot be negative");
        Modules = modules ?? new Modul[0];
    }

    public Project() : this("Unnamed", ProjectType.PersonalUse, DateTime.Now, 0.0, new Modul[0]) { }

    public double AverageModuleSize =>
        Modules.Length > 0 ? Modules.Average(m => m.SizeModul) : 0;

    public bool this[ProjectType pt] => Type == pt;

    public void AddModuls(params Modul[] newModules) =>
        Modules = Modules.Concat(newModules).ToArray();

    public override string ToString()
    {
        string moduleList = string.Join("\n", Modules.Select(m => m.ToString()));
        return $"Project: {Name}\nType: {Type}\nEnd Date: {EndDate:dd.MM.yyyy}\nPrice: {Price}\nAverage Module Size: {AverageModuleSize:F2}\nModules:\n{moduleList}";
    }

    public string ToShortString() =>
        $"Project: {Name}, Type: {Type}, End Date: {EndDate:dd.MM.yyyy}, Price: {Price}, AvgSize: {AverageModuleSize:F2}";

    public object Clone()
    {
        Modul[] clonedModules = Modules.Select(m => (Modul)m.Clone()).ToArray();
        return new Project(Name, Type, EndDate, Price, clonedModules);
    }
}