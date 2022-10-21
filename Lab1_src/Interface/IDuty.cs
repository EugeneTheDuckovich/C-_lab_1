using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_src.Interface;

internal interface IDuty
{
    string Name { get; }
    DutyDifficulty Difficulty { get; }
}
