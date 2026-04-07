using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int choice = 0;

        while (choice != 10)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goal Names");
            Console.WriteLine("3. List Goal Details");
            Console.WriteLine("4. Create New Goal");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Save Goals");
            Console.WriteLine("7. Load Goals");
            Console.WriteLine("8. Edit Goal");
            Console.WriteLine("9. Delete Goal");
            Console.WriteLine("10. Quit");

            Console.Write("Select a choice from the menu: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    DisplayPlayerInfo();
                    break;

                case 2:
                    ListGoalNames();
                    break;

                case 3:
                    ListGoalDetails();
                    break;

                case 4:
                    CreateGoal();
                    break;

                case 5:
                    RecordEvent();
                    break;

                case 6:
                    SaveGoals();
                    break;

                case 7:
                    LoadGoals();
                    break;

                case 8:
                    EditGoal();
                    break;

                case 9:
                    DeleteGoal();
                    break;

                case 10:
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // -----------------------------
    // DISPLAY PLAYER INFO
    // -----------------------------
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYour current score is: {_score} points");
    }

    // -----------------------------
    // LIST GOAL NAMES
    // -----------------------------
    public void ListGoalNames()
    {
        Console.WriteLine("\nGoal Names:");
        int index = 1;

        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{index}. {goal.GetShortName()}");
            index++;
        }
    }

    // -----------------------------
    // LIST GOAL DETAILS
    // -----------------------------
    public void ListGoalDetails()
    {
        Console.WriteLine("\nGoal Details:");
        int index = 1;

        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{index}. {goal.GetDetailsString()}");
            index++;
        }
    }

    // -----------------------------
    // CREATE GOAL
    // -----------------------------
    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int choice))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        Console.Write("Enter the short name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                break;

            case 2:
                _goals.Add(new EternalGoal(name, description, points));
                break;

            case 3:
                Console.Write("Enter the target number of completions: ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("Enter the bonus points: ");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    // -----------------------------
    // RECORD EVENT
    // -----------------------------
    public void RecordEvent()
    {
        Console.WriteLine("\nWhich goal did you accomplish?");
        ListGoalNames();

        Console.Write("Enter the goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[index];
        int pointsEarned = goal.RecordEvent();

        _score += pointsEarned;

        Console.WriteLine($"You earned {pointsEarned} points!");
        Console.WriteLine($"Your new score is {_score} points.");
    }

    // -----------------------------
    // SAVE GOALS
    // -----------------------------
    public void SaveGoals()
    {
        Console.Write("Enter the filename to save to: ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    // -----------------------------
    // LOAD GOALS
    // -----------------------------
    public void LoadGoals()
    {
        Console.Write("Enter the filename to load from: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _goals.Clear();

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string goalType = parts[0];
            string data = parts[1];

            string[] details = data.Split(",");

            if (goalType == "SimpleGoal")
            {
                SimpleGoal g = new SimpleGoal(details[0], details[1], int.Parse(details[2]));
                if (details[3] == "true")
                {
                    g.MarkComplete();
                }
                _goals.Add(g);
            }
            else if (goalType == "EternalGoal")
            {
                _goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
            }
            else if (goalType == "ChecklistGoal")
            {
                ChecklistGoal g = new ChecklistGoal(
                    details[0],
                    details[1],
                    int.Parse(details[2]),
                    int.Parse(details[4]),
                    int.Parse(details[5])
                );
                g.SetAmountCompleted(int.Parse(details[3]));
                _goals.Add(g);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    // -----------------------------
    // EDIT GOAL
    // -----------------------------
    public void EditGoal()
    {
        Console.WriteLine("\nWhich goal would you like to edit?");
        ListGoalNames();

        Console.Write("Enter the goal number: ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int index))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        index -= 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[index];

        Console.WriteLine("\nWhat would you like to edit?");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Description");
        Console.WriteLine("3. Points");

        if (goal is SimpleGoal)
            Console.WriteLine("4. Mark as incomplete");

        if (goal is ChecklistGoal cg)
        {
            Console.WriteLine($"5. Target (current: {cg.GetTarget()})");
            Console.WriteLine($"6. Bonus (current: {cg.GetBonus()})");
            Console.WriteLine($"7. Reset progress (current: {cg.GetAmountCompleted()})");
        }

        Console.WriteLine("8. Cancel");

        Console.Write("Choose an option: ");
        string editInput = Console.ReadLine();

        if (!int.TryParse(editInput, out int editChoice))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        switch (editChoice)
        {
            case 1:
                Console.Write("Enter new name: ");
                goal.SetName(Console.ReadLine());
                break;

            case 2:
                Console.Write("Enter new description: ");
                goal.SetDescription(Console.ReadLine());
                break;

            case 3:
                Console.Write("Enter new points: ");
                goal.SetPoints(int.Parse(Console.ReadLine()));
                break;

            case 4:
                if (goal is SimpleGoal sg)
                {
                    sg.Reset();
                    Console.WriteLine("SimpleGoal marked as incomplete.");
                }
                break;

            case 5:
                if (goal is ChecklistGoal cg1)
                {
                    Console.Write("Enter new target: ");
                    cg1.SetTarget(int.Parse(Console.ReadLine()));
                }
                break;

            case 6:
                if (goal is ChecklistGoal cg2)
                {
                    Console.Write("Enter new bonus: ");
                    cg2.SetBonus(int.Parse(Console.ReadLine()));
                }
                break;

            case 7:
                if (goal is ChecklistGoal cg3)
                {
                    cg3.SetAmountCompleted(0);
                    Console.WriteLine("Progress reset.");
                }
                break;

            case 8:
                Console.WriteLine("Edit canceled.");
                return;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }

        Console.WriteLine("Goal updated successfully.");
    }

    // -----------------------------
    // DELETE GOAL
    // -----------------------------
    public void DeleteGoal()
    {
        Console.WriteLine("\nWhich goal would you like to delete?");
        ListGoalNames();

        Console.Write("Enter the goal number: ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int index))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        index -= 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Console.WriteLine($"Are you sure you want to delete '{_goals[index].GetShortName()}'? (y/n)");
        string confirm = Console.ReadLine().ToLower();

        if (confirm == "y")
        {
            _goals.RemoveAt(index);
            Console.WriteLine("Goal deleted successfully.");
        }
        else
        {
            Console.WriteLine("Deletion canceled.");
        }
    }
}
