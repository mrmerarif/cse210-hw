public class Swimming : Activity // Swimming class that inherits from the abstract Activity class, representing a swimming activity
{
    private int _laps;  // private field to store the number of laps swum in the swimming activity

    public Swimming(string date, int minutes, int laps) // constructor to initialize the date, minutes, and laps fields, calling the base class constructor
        : base(date, minutes) // call the base class constructor to initialize the date and minutes fields
    {
        _laps = laps; // initialize the laps field with the provided value
    }

    public override double GetDistance() // override the GetDistance method to calculate and return the distance of the swimming activity based on the number of laps swum
    {
        double km = (_laps * 50) / 1000.0; // calculate distance in kilometers (assuming each lap is 50 meters)
        return km * 0.62; // convert to miles
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}
