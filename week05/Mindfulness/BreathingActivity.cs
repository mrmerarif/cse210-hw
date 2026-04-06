using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing",
               "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        // Show the starting message from the base class
        DisplayStartingMessage();

        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration); // Calculate the end time based on the duration specified by the user

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            ShowCountDown(4); // Show the countdown for 4 seconds

            Console.WriteLine();

            Console.Write("Breathe out... ");
            ShowCountDown(6);  // Show the countdown for 6 seconds

            Console.WriteLine("\n"); // Add a line break between cycles
        }

        // Show the ending message from the base class
        DisplayEndingMessage();
    }
}
