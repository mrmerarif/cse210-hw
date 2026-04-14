public abstract class Activity
{
    private DateTime _date; // private field to store the date of the activity as a DateTime object
    private int _minutes;   // private field to store the duration of the activity in minutes

    public Activity(string date, int minutes) // constructor to initialize the date and minutes fields
    {
        _date = DateTime.Parse(date); // convert the string into a DateTime
        _minutes = minutes;           // initialize the minutes field with the provided value
    }

    public string GetDate() // method to retrieve the date of the activity
    {
        // format the date like "03 Nov 2022"
        return _date.ToString("dd MMM yyyy");
    }

    public int GetMinutes() // method to retrieve the minutes
    {
        return _minutes;
    }

    public abstract double GetDistance(); // abstract method to calculate the distance of the activity
    public abstract double GetSpeed();    // abstract method to calculate the speed
    public abstract double GetPace();     // abstract method to calculate the pace

    public virtual string GetSummary() // method to return a formatted summary of the activity
    {
        string dateText = GetDate(); // get the formatted date

        return $"{dateText} {this.GetType().Name} ({_minutes} min) - " +
               $"Distance {GetDistance():0.0} miles, " +
               $"Speed {GetSpeed():0.0} mph, " +
               $"Pace {GetPace():0.0} min per mile";
    }
}

