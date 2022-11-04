using Lab1_src.Model;

namespace Lab1_src.Controllers;

internal interface IDutyPlanner
{
    string Name { get; }
    Duty[] GetDuties();
    string[] GetStory();
    int GetDutiesExecutionTime();
    void AddDuty(Duty duty);
    public void AddDutyRange(IEnumerable<Duty> duties);
    void ExecuteDuty(int index);
    void RemoveDuty(int index);
    void ExecuteAll();
    void ClearDuties();
    void ClearStory();
}