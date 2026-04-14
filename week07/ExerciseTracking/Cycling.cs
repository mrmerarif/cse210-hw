public class Cycling : Activity // Cycling class that inherits from the abstract Activity class, representing a cycling activity
{
    private double _speed; // private field to store the speed of the cycling activity in miles per hour

    public Cycling(string date, int minutes, double speed) // constructor to initialize the date, minutes, and speed fields, calling the base class constructor
        : base(date, minutes) // call the base class constructor to initialize the date and minutes fields
    {
        _speed = speed; // initialize the speed field with the provided value
    }

    public override double GetDistance() // override the GetDistance method to calculate and return the distance of the cycling activity based on the speed and duration
    {
        return (_speed * GetMinutes()) / 60; // distance = speed * time, where time is converted from minutes to hours
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}
