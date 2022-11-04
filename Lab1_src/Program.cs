// See https://aka.ms/new-console-template for more information

using Lab1_src.Model;
using Lab1_src.Controllers;
using Lab1_src.View;

var dutyViewer = new DutyPlannerViewer(new DutyPlanner("My Duty Planner"));

dutyViewer.DutyPlanner.AddDutyRange(new Duty[]{
    new Duty("Very Easy Duty", DutyDifficulty.VeryEasy),
    new Duty("Hard Duty", DutyDifficulty.Hard)
});

dutyViewer.Start();