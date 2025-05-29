namespace lb7_2;

public class Register
{
    public List<Devices> DeviceList { get; private set; } = new List<Devices>();

    public void AddDevice(Devices device)
    {
        DeviceList.Add(device);
    }

    public void PrintAll()
    {
        Console.WriteLine("Усе обладнання:");
        foreach (var d in DeviceList)
        {
            Console.WriteLine(d);
        }
    }

    public void PrintElectronic()
    {
        Console.WriteLine("Електронне обладнання:");
        foreach (var d in DeviceList.Where(d => d.IsElectronic))
        {
            Console.WriteLine(d);
        }
    }

    public void PrintNoEngine()
    {
        Console.WriteLine("Обладнання без двигунів:");
        foreach (var d in DeviceList.Where(d => !(d is IEngine)))
        {
            Console.WriteLine(d);
        }
    }

    public void RequestAndSort()
    {
        while (true)
        {
            Console.WriteLine("Введіть перший критерій (1 - Ім'я, 2 - Вага, 3 - Електроніка, 0 - не сортувати):");
            if (!int.TryParse(Console.ReadLine(), out int primary) || primary < 0 || primary > 3)
            {
                Console.WriteLine("Невірне значення. Спробуйте ще раз.");
                continue;
            }
            if (primary == 0)
            {
                Console.WriteLine("Сортування скасовано.");
                return;
            }

            Console.WriteLine("Введіть другий критерій (має бути інший):");
            if (!int.TryParse(Console.ReadLine(), out int secondary) || secondary < 1 || secondary > 3)
            {
                Console.WriteLine("Невірне значення. Спробуйте ще раз.");
                continue;
            }

            if (primary == secondary)
            {
                Console.WriteLine("Критерії мають бути різні.");
                continue;
            }

            SortByTwoCriteria(primary, secondary);
            break;
        }
    }
    private int CompareByKey(Devices x, Devices y, int key)
    {
        return key switch
        {
            1 => string.Compare(x.Name, y.Name, StringComparison.Ordinal),
            2 => x.Weight.CompareTo(y.Weight),
            3 => x.IsElectronic.CompareTo(y.IsElectronic),
            _ => 0
        };
    }
    private void SortByTwoCriteria(int primary, int secondary)
    {
        Comparison<Devices> comparison = (x, y) =>
        {
            int result = CompareByKey(x, y, primary);
            if (result == 0)
            {
                result = CompareByKey(x, y, secondary);
            }
            return result;
        };

        DeviceList.Sort(comparison);
    }
}