using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();


        string name = PromptUserName();
        int number = PromptUserNumber();

        // Calculate the square of the number
        int squaredNumber = SquareNumber(number);

        DisplayResult(name, squaredNumber);
    }
    // Method to display a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    // Method to prompt the user for their name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Method to prompt the user for their favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string input = Console.ReadLine();
        int number = int.Parse(input);
        return number;
    }

    // Method to calculate the square of a number
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    // Method to display the result
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}
