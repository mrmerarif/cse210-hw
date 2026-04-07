using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }


    public void SetName(string value)
    {
        _shortName = value;
    }

    public void SetDescription(string value)
    {
        _description = value;
    }

    public void SetPoints(int value)
    {
        _points = value;
    }

    public string GetShortName()
    {
        return _shortName;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        return $"[ ] {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();
}
