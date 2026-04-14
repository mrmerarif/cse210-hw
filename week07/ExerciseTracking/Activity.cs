public abstract class Activity
{
    private string _date; // private field to store the date of the activity
    private int _minutes;  // private field to store the duration of the activity in minutes

    public Activity(string date, int minutes) // constructor to initialize the date and minutes fields
    {
        _date = date;
        _minutes = minutes; // initialize the minutes field with the provided value
    }

    public string GetDate() // method to retrieve the date of the activity
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance();  // abstract method to calculate the distance of the activity, to be implemented by derived classes
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_date} {this.GetType().Name} ({_minutes} min) - " +
               $"Distance {GetDistance():0.0} miles, " +
               $"Speed {GetSpeed():0.0} mph, " +
               $"Pace {GetPace():0.0} min per mile";  // virtual method to provide a summary of the activity, can be overridden by derived classes if needed
    }
}
