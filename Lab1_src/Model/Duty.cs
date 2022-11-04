using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_src.Model;

internal struct Duty
{
    public string Name { get; }
    public DutyDifficulty Difficulty { get; }
    public Duty(string name, DutyDifficulty difficulty)
    {
        Name = name;
        Difficulty = difficulty;
    }
}
