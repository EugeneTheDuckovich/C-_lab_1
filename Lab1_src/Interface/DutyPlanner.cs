using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_src.Interface
{
    
    internal interface DutyPlanner
    {
        static string Name { get; } = "Duty Planner";
        IDuty[] Duties { get; }
        uint DutiesAmount { get; }
        string[] Story { get; set; }
    }
}
