using Lab1_src.Model;

namespace Lab1_src.Controllers;

internal class DutyPlanner : IDutyPlanner
{
    private List<Duty> _duties;
    private List<string> _story;

    public string Name { get; }

    public Duty[] GetDuties()
    {
        return _duties.ToArray();
    }

    public string[] GetStory()
    {
        return _story.ToArray();
    }

    public DutyPlanner(string name, IEnumerable<Duty> duties = null)
    {
        Name = name;
        if (Name == null || Name == "")
        {
            Name = "Default name";
        }
        _story = new List<string>();
        if (duties != null) _duties = duties.ToList();
        else _duties = new List<Duty>();
    }

    public void AddDuty(Duty duty)
    {
        _duties.Add(duty);
    }

    public void AddDutyRange(IEnumerable<Duty> duties)
    {
        _duties.AddRange(duties);
    }

    public void RemoveDuty(int index)
    {
        _duties.RemoveAt(index);
    }

    public void ExecuteDuty(int index)
    {
        _story.Add(_duties[index].Name);
        _duties.RemoveAt(index);
    }

    public void ExecuteAll()
    {
        _story.AddRange(_duties.Select(d => d.Name));
        _duties.Clear();
    }

    public void ClearDuties()
    {
        _duties.Clear();
    }

    public void ClearStory()
    {
        _story.Clear();
    }

    public int GetDutiesExecutionTime()
    {
        if(_duties.Count == 0) return 0;
        return _duties
            .Select(d => (int)d.Difficulty)
            .Aggregate((x, y) => x + y);
    }
}