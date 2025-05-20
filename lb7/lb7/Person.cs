using System.Text.RegularExpressions;

public class Person : IComparable<Person>, ICloneable
{
    private string name;
    private string surname;
    private DateTime dateOfBirth;

    public Person(string name, string surname, DateTime dateOfBirth)
    {
        Name = name;
        Surname = surname;
        DateOfBirth = dateOfBirth;
    }

    public Person()
    {
        name = "Noname";
        surname = "Nosurname";
        dateOfBirth = new DateTime(0);
    }

    public string Name
    {
        get => name;
        set
        {
            string pattern = @"^[a-zA-Z]+$";
            name = Regex.IsMatch(value, pattern) ? value : "Noname";
        }
    }

    public string Surname
    {
        get => surname;
        set
        {
            string pattern = @"^[a-zA-Z]+$";
            surname = Regex.IsMatch(value, pattern) ? value : "Nosurname";
        }
    }

    public DateTime DateOfBirth
    {
        get => dateOfBirth;
        set => dateOfBirth = value.Year <= DateTime.Now.Year ? value : new DateTime(0);
    }

    public override string ToString() =>
        $"Name: {name}\nSurname: {surname}\nDateOfBirth: {dateOfBirth}";

    public string ToShortString() =>
        $"Name: {name} Surname: {surname}";

    public int CompareTo(Person? other)
    {
        if (other == null) return 1;
        int result = Surname.CompareTo(other.Surname);
        return result != 0 ? result : Name.CompareTo(other.Name);
    }

    public object Clone() =>
        new Person(name, surname, dateOfBirth);
}