using System.ComponentModel;

namespace LB7;

public enum TypeOfWork
{
    Home,
    Business,
    Server
}

public class Computer : IContainer<Device>, IFileContainer<Device>
{
    private Person _person;
    private TypeOfWork _type;
    private string _ip;
    private Device[] _device;

    public int Count => _device.Length;
    public bool IsDataSaved { get; set; }

    object IContainer<Device>.this[int index]
    {
        get => this[index];
        set => this[index] = (Device)value;
    }

    public void Save(string fileName)
    {
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            foreach (var device in _device)
            {
                sw.WriteLine(device.ToString());
            }
        }
        IsDataSaved = true;
        
    }

    public void Load(string fileName)
    {
        using (StreamReader sr = new StreamReader(fileName))
        {
            foreach (var device in _device)
            {
                sr.ReadLine();
            }
        }
        IsDataSaved = true;
    }

    public void Add(Device el)
    {
        Array.Resize(ref _device, _device.Length + 1);
        _device[_device.Length - 1] = el;
    }

    public void Delete(Device el)
    {
        _device[_device.Length - 1] = null;
        Array.Resize(ref _device, _device.Length - 1);
    }

    public Device this[int index]
    {
        get => _device[index];
        set => _device[index] = value;
    }


    public Computer(Person person, TypeOfWork type, string ip, Device[] device)
    {
        _person = person;
        _type = type;
        _ip = ip;
        _device = device;
    }

    public Computer()
    {
        _person = new Person();
        _type = TypeOfWork.Home;
        _ip = "0.0.0.0";
        _device = new Device[1];
    }

    public Person Person
    {
        get => _person;
        set => _person = value;
    }

    public TypeOfWork Type
    {
        get => _type;
        set => _type = value;
    }

    public string Ip
    {
        get => _ip;
        set => _ip = value;
    }

    public Device[] Device
    {
        get => _device;
        set => _device = value;
    }

    public double TotalPrice
    {
        get
        {
            double total = 0;
            foreach (var i in _device)
                total += i.Price;
            return total;
        }
    }

    public void AddDevice(params Device[]? newDevice)
    {
        if (newDevice == null) return;
        int oldLength = _device.Length;
        Array.Resize(ref _device, oldLength + newDevice.Length);
        Array.Copy(newDevice, 0, _device, oldLength, newDevice.Length);
    }

    public bool this[TypeOfWork type] => _type == type;

    public override string ToString()
    {
        return $"{_person}\nПризначення: {_type}, IP: {_ip}\nПристрої:\n{_device.ToString()}";
    }

    public string ToShortString()
    {
        return $"{_person.ToShortString()}, Призначення: {_type}, IP: {_ip}, Загальна вартість пристроїв: {TotalPrice}";
    }
}