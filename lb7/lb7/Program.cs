using lb7;

class Program
{
    static void Main()
    {
        Person p1 = new("Ivan", "Petrenko", new DateTime(1995, 4, 10));
        Person p2 = new("Maria", "Koval", new DateTime(1993, 8, 20));

        Modul m1 = new(p1, "Databases", 4.2);
        Modul m2 = new(p2, "UI/UX", 3.8);

        ProjectContainer container = new();

        container.Add(new Project("ERP", ProjectType.Commercial, DateTime.Now.AddMonths(1), 20000, new[] { m1 }));
        container.Add(new Project("Education Portal", ProjectType.Training, DateTime.Now, 8000, new[] { m1, m2 }));
        container.Add(new Project("Personal Blog", ProjectType.PersonalUse, DateTime.Now.AddDays(5), 500, new[] { m2 }));

        // Сортування
        var sorted = container.OrderBy(p => p.Name).ToList();
        for (int i = 0; i < sorted.Count; i++)
            container[i] = sorted[i];

        Console.WriteLine("\n=== Sorted Projects ===");
        foreach (var p in container)
            Console.WriteLine(p.ToShortString());

        container.Save("projects.txt");

        // Копіювання
        ProjectContainer copyContainer = new();
        for (int i = 0; i < Math.Min(2, container.Count); i++)
            copyContainer.Add((Project)container[i].Clone());

        Console.WriteLine("\n=== Copied Projects ===");
        foreach (var p in copyContainer)
            Console.WriteLine(p.ToShortString());

        copyContainer.Save("copied_projects.txt");
        Console.ReadKey();
    }
}