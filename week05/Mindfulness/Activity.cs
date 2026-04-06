using System;
using System.Collections.Generic;
using System.Threading;  // Added for thread sleeping to create delays in the activities
using System.IO;   // Added for file handling to log sessions

public class Activity // Base class for all activities, containing common properties and methods
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)  // Constructor to initialize the activity with a name and description
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like this session to last? ");

        // Get duration from user
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nGet ready to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2); // Show a spinner for 2 seconds before displaying the final message

        Console.WriteLine($"\nYou have completed the {_name} Activity for {_duration} seconds.");  // Display a message indicating the completion of the activity and the duration spent on it
        ShowSpinner(3); // Show a spinner for 3 seconds to give the user time to read the completion message

        LogSession();   // Log the session details to a file for future reference or tracking of progress
    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string> { "|", "/", "-", "\\" };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0; // Variable to keep track of the current index in the spinner list

        while (DateTime.Now < endTime) // Loop until the current time is less than the end time
        {
            Console.Write(spinner[index]);
            Thread.Sleep(200);  // Pause for 200 milliseconds to create the spinning effect
            Console.Write("\b \b");

            index++;
            if (index >= spinner.Count) // If the index exceeds the number of spinner characters, reset it to 0 to loop through the spinner again
            {
                index = 0;
            }
        }
    }

    public void ShowCountDown(int seconds) // Method to show a countdown timer for a specified number of seconds
    {
        for (int i = seconds; i > 0; i--) // Loop from the specified number of seconds down to 1
        {
            Console.Write(i);
            Thread.Sleep(1000); // Pause for 1 second to create the countdown effect
            Console.Write("\b \b");
        }
    }

    public void LogSession()
    {
        string logEntry = $"[{DateTime.Now}] Completed {_name} Activity for {_duration} seconds"; // Create a log entry with the current date and time, activity name, and duration
        File.AppendAllText("session_log.txt", logEntry + Environment.NewLine); // Append the log entry to a file named "session_log.txt", creating the file if it doesn't exist
    }
}
