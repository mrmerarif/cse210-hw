public class Running : Activity  // Running class that inherits from the abstract Activity class, representing a running activity
{
    private double _distance; // private field to store the distance of the running activity in miles

    public Running(string date, int minutes, double distance) // constructor to initialize the date, minutes, and distance fields, calling the base class constructor
        : base(date, minutes)  // call the base class constructor to initialize the date and minutes fields
    {
        _distance = distance; // initialize the distance field with the provided value
    }

    public override double GetDistance() // override the GetDistance method to return the distance of the running activity
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / _distance;
    }
}
