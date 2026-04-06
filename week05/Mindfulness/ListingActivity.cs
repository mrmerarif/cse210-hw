using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>(); // List to hold the prompts for the activity
    private int _count = 0; // Variable to keep track of the number of items listed by the user

    public ListingActivity() // Constructor to initialize the activity with a name, description, and prompts
        : base("Listing",
               "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
    }

    private string GetRandomPrompt()  // Method to get a random prompt from the list
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);  // Generate a random index based on the number of prompts
        return _prompts[index];
    }

    private List<string> GetListFromUser()  // Method to get a list of items from the user until the time runs out
    {
        List<string> responses = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);  // Calculate the end time based on the duration specified by the user

        while (DateTime.Now < endTime)  // Loop until the current time is less than the end time
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            responses.Add(item);
            _count++;
        }

        return responses;
    }

    public void Run()  // Method to run the activity, which includes displaying the starting message, showing a random prompt, getting user input, and displaying the ending message
    {
        DisplayStartingMessage();

        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");

        Console.WriteLine("\nYou may begin in: ");
        ShowCountDown(5);

        Console.WriteLine();

        List<string> items = GetListFromUser();  // Get the list of items from the user and store it in a variable

        Console.WriteLine($"\nYou listed {_count} items:"); // Display the count of items listed by the user
        foreach (string item in items)
        {
            Console.WriteLine($"- {item}");
        }

        DisplayEndingMessage();
    }
}
