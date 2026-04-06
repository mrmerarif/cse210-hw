using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();

    public ReflectingActivity()
        : base("Reflecting",
               "This activity will help you reflect on times in your life when you have shown strength and resilience. " +
               "This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        // Load prompts
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");

        // Load questions
        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();  // Create a new instance of Random
        int index = rand.Next(_prompts.Count);  // Generate a random index based on the number of prompts
        return _prompts[index];
    }

    private string GetRandomQuestion() // Method to get a random question from the list
    {
        Random rand = new Random(); // Create a new instance of Random
        int index = rand.Next(_questions.Count); // Generate a random index based on the number of questions
        return _questions[index];
    }

    private void DisplayPrompt()
    {
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine("\nWhen you have something in mind, press Enter to continue.");
        Console.ReadLine();
    }

    private void DisplayQuestions()
    {
        Console.WriteLine("\nNow ponder on each of the following questions:");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);  // Calculate the end time based on the duration specified by the user

        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion(); // Get a random question from the list
            Console.Write($"> {question} "); // Display the question to the user
            ShowSpinner(5);  // Show a spinner for 5 seconds to give the user time to reflect on the question
            Console.WriteLine();
        }
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        DisplayQuestions();
        DisplayEndingMessage();
    }
}
