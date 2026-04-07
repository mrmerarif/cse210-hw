using System;

public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
    }

    public override int RecordEvent()
    {
        // Eternal goals never complete, always award points
        return _points;
    }

    public override bool IsComplete()
    {
        // Eternal goals are never complete
        return false;
    }

    public override string GetDetailsString()
    {
        // Always unchecked because eternal goals never complete
        return $"[ ] {_shortName} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        // Format: EternalGoal:Name,Description,Points
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }

    // Helper for GoalManager listing
    public string GetShortName()
    {
        return _shortName;
    }
}
