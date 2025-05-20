using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace lb7;

public class ProjectContainer : IContainer<Project>, IFileContainer, IEnumerable<Project>
{
    private List<Project> projects = new();
    private bool isDataSaved = false;

    public int Count => projects.Count;
    public bool IsDataSaved => isDataSaved;

    public Project this[int index]
    {
        get
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            return projects[index];
        }
        set
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            projects[index] = value;
        }
    }

    public void Add(Project element)
    {
        projects.Add(element);
        isDataSaved = false;
    }

    public void Delete(Project element)
    {
        projects.Remove(element);
        isDataSaved = false;
    }

    public void Save(string fileName)
    {
        using StreamWriter writer = new(fileName);
        foreach (var p in projects)
        {
            writer.WriteLine(p.ToString());
            writer.WriteLine("-----");
        }
        isDataSaved = true;
    }

    public void Load(string fileName)
    {
        throw new NotImplementedException("Load() реалізуйте вручну, якщо потрібно.");
    }
    
    public IEnumerator<Project> GetEnumerator()
    {
        foreach (var project in projects)
            yield return project;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}