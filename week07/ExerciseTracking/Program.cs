using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>(); // create a list to store different types of activities
        Console.WriteLine();
        activities.Add(new Running("03/17/2023", 30, 3.0)); // add a Running activity to the list with date, duration in minutes, and distance in miles
        activities.Add(new Cycling("03/18/2023", 60, 15.0)); // add a Cycling activity to the list with date, duration in minutes, and speed in miles per hour
        activities.Add(new Swimming("03/19/2023", 45, 20)); // add a Swimming activity to the list with date, duration in minutes, and number of laps swum
        foreach (Activity activity in activities) // iterate through each activity in the list
        {
            Console.WriteLine(activity.GetSummary()); // print the summary of each activity using the GetSummary method
            Console.WriteLine(); // 
        }
    }
}