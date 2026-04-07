// I added an option that allows full editing of a goal. 
// Users can update the goal name, description, points, and type‑specific fields.
// For SimpleGoal, the user can reset it to incomplete. 
// For ChecklistGoal, the target and bonus can be edited, and progress can be reset.
//
// I also added a Delete Goal feature, which safely removes goals with validation 
// and a confirmation prompt. This helps users fix mistakes or remove outdated goals.


using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
