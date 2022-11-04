using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_src.Controllers;
using Lab1_src.Converters;
using Lab1_src.Model;

namespace Lab1_src.View;

internal class DutyPlannerViewer
{
    private IDutyPlanner _dutyPlanner;

    public IDutyPlanner DutyPlanner { get { return _dutyPlanner; } }

    public DutyPlannerViewer(IDutyPlanner dutyPlanner)
    {
        _dutyPlanner = dutyPlanner;
    }

    public void Start()
    {
        while (true)
        {
            MainMenu();
        }
    }

    private void MainMenu()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to {_dutyPlanner.Name}!");
        Console.WriteLine("1. Show current duties");
        Console.WriteLine("2. Show work story");
        Console.WriteLine("3. Add duty");
        Console.WriteLine("4. Execute duty");
        Console.WriteLine("5. Remove duty");
        Console.WriteLine("6. Clear duties");
        Console.WriteLine("7. Clear story");
        Console.WriteLine("8. Exit");
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                ViewDutiesMenu();
                break;
            case "2":
                ViewStoryMenu();
                break;
            case "3":
                AddDutyMenu();
                break;
            case "4":
                ExecuteDutyMenu();
                break;
            case "5":
                RemoveDutyMenu();
                break;
            case "6":
                ClearDuties();
                break;
            case "7":
                ClearStory();
                break;
            case "8":
                Exit();
                break;
            default:
                Console.WriteLine("invalid input!");
                Thread.Sleep(1000);
                break;
        }
    }

    private void ViewDutiesMenu()
    {
        Console.Clear();
        if (_dutyPlanner.GetDuties().Length == 0)
        {
            Console.WriteLine("you have no duties. press ENTER to go to main menu");
            Console.ReadLine();
            return;
        }
        Console.WriteLine("current duties:");

        foreach (var duty in _dutyPlanner.GetDuties())
        {
            Console.WriteLine($"{duty.Name}, {duty.Difficulty}");   
        }

        Console.WriteLine($"summary execution time: {_dutyPlanner.GetDutiesExecutionTime()}");
        Console.WriteLine("press ENTER to go to main menu");

        Console.Read();
    }

    private void ViewStoryMenu()
    {
        Console.Clear();

        if (_dutyPlanner.GetStory().Length == 0)
        {
            Console.WriteLine("your story is empty. press ENTER to go to main menu");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("story of work:");
        foreach(var item in _dutyPlanner.GetStory().Reverse())
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("press ENTER to go to main menu");
        Console.Read();
    }

    private void AddDutyMenu()
    {
        Console.Clear();
        Console.WriteLine("input nothing and press ENTER to go to main menu ");
        Console.WriteLine("to add new duty input data in format *duty name*, *duty difficulty*");
        Console.WriteLine("where duty difficulty is a number from 1 to 5");

        var input = Console.ReadLine();

        if (input == "") 
        { 
            return; 
        }

        var duty = input.ToDuty();

        if (duty != null)
        {
            _dutyPlanner.AddDuty((Duty)duty);
            Console.WriteLine("duty was successfully added!");
            Thread.Sleep(2000);
        }
        else
        {
            Console.WriteLine("invalid format!");
            Thread.Sleep(1000);
        }
        AddDutyMenu();
    }

    private void ExecuteDutyMenu()
    {
        Console.Clear();
        if (_dutyPlanner.GetDuties().Length == 0)
        {
            Console.WriteLine("you have nothing to execute. press ENTER to go to main menu");
            Console.ReadLine();
            return;
        }
        EnumerateDuties();
        Console.WriteLine("input nothing and press ENTER to go to main menu ");
        Console.WriteLine("input one number to execute one duty");
        Console.WriteLine("input several numbers with comas between them to execute several duties");

        string input = Console.ReadLine();
        if (input == null || input == "") return;

        var indexes = input.ToIndexArray();

        if (indexes == null
            || indexes.Any(i => i > _dutyPlanner.GetDuties().Length)
            || indexes.Count() > _dutyPlanner.GetDuties().Length)
        {
            Console.WriteLine("invalid argument, try again!");
            Thread.Sleep(1000);
            RemoveDutyMenu();
            return;
        }

        indexes.OrderByDescending(x => x).Distinct();

        foreach (var index in indexes)
        {
            _dutyPlanner.ExecuteDuty(index - 1);
        }
        ExecuteDutyMenu();
    }

    private void RemoveDutyMenu()
    {
        Console.Clear();
        if (_dutyPlanner.GetDuties().Length == 0)
        {
            Console.WriteLine("you have nothing to remove. press ENTER to go to main menu");
            Console.ReadLine();
            return;
        }
        EnumerateDuties();
        Console.WriteLine("input nothing and press ENTER to go to main menu ");
        Console.WriteLine("input one number to execute remove duty");
        Console.WriteLine("input several numbers with comas between them to remove several duties");

        string input = Console.ReadLine();
        if (input == null || input == "") return;

        var indexes = input.ToIndexArray();

        if (indexes == null 
            || indexes.Any(i => i > _dutyPlanner.GetDuties().Length) 
            || indexes.Count() > _dutyPlanner.GetDuties().Length)
        {
            Console.WriteLine("invalid argument, try again!");
            Thread.Sleep(1000);
            RemoveDutyMenu();
            return;
        }

        indexes.OrderByDescending(i => i).Distinct();

        foreach (var index in indexes)
        {
            _dutyPlanner.RemoveDuty(index - 1);
        }
        RemoveDutyMenu();
    }

    private void ClearDuties()
    {
        _dutyPlanner.ClearDuties();
        Console.WriteLine("duties list was successfully cleared");
        Thread.Sleep(1000);
    }

    private void ClearStory()
    {
        _dutyPlanner.ClearStory();
        Console.WriteLine("story was successfully cleared");
        Thread.Sleep(1000);
    }

    private void Exit()
    {
        Console.WriteLine("Exiting programm...");
        Thread.Sleep(1000);
        Environment.Exit(0);
    }

    private void EnumerateDuties()
    {
        var duties = _dutyPlanner.GetDuties();
        for (int i = 0; i < duties.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {duties[i].Name}, {duties[i].Difficulty}");
        }
    }
}