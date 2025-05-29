using System.Text.RegularExpressions;

namespace LB7;

public class Person : IComparable<Person>, ICloneable
{
    private string _name;
    private string _surname;
    private DateTime _dateOfBirth;

    public Person(string name, string surname, DateTime dateOfBirth)
    {
        _name = name;
        _surname = surname;
        _dateOfBirth = dateOfBirth;
    }

    public Person()
    {
        _name = "Noname";
        _surname = "Nosurname";
        _dateOfBirth = new DateTime(2000, 1, 1);
    }

    public static bool CheckName(string s)
    {
        return Regex.IsMatch(s.Trim(), @"^[a-zA-Z]+$");
    }

    public string Name
    {
        get => _name;
        set
        {
            if (!String.IsNullOrEmpty(value) && CheckName(value))
                _name = value;
        }
    }

    public string Surname
    {
        get => _surname;
        set
        {
            if (!String.IsNullOrEmpty(value) && CheckName(value))
                _surname = value;
        }
    }

    public DateTime DateOfBirth
    {
        get => _dateOfBirth;
        set
        {
            if (DateTime.Now < value)
                _dateOfBirth = new DateTime(value.Year, value.Month, value.Day);
        }
    }

    public int CompareTo(Person other)
    {
        if (other == null) return 1;

        int result = string.Compare(_surname, other._surname, StringComparison.OrdinalIgnoreCase);
        if (result != 0) return result;

        result = string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        if (result != 0) return result;

        result = DateOfBirth.CompareTo(other.DateOfBirth);
        return result;
    }

    public object CloneTo()
    {
        return new Person()
        {
            _name = this._name,
            _surname = this._surname,
            _dateOfBirth = this._dateOfBirth
        };
    }

    public override string ToString()
    {
        return $"{_name} {_surname}, Дата народження: {_dateOfBirth}";
    }

    public string ToShortString()
    {
        return $"{_name} {_surname}";
    }
}