using System;
using System.Collections.Generic;

class Program
{
    // This program reads a list of numbers from the user, computes the sum, average, and largest number, and displays the results.
    static void Main(string[] args)
    {
        // Create a list to store the numbers
        List<int> numbers = new List<int>();


        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Initialize the number variable
        int number = -1;

        // Read numbers from the user until they enter 0
        while (number != 0)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            number = int.Parse(input);

            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        // Compute the sum
        int sum = 0;
        // Use a foreach loop to iterate through the list of numbers and add them to the sum
        foreach (int n in numbers)
        {
            // Add the current number to the sum
            sum += n;
        }

        // Compute the average
        float average = ((float)sum) / numbers.Count;

        // Find the largest number
        int max = numbers[0];

        // Use a foreach loop to iterate through the list of numbers and find the largest number
        foreach (int n in numbers)
        {
            // If the current number is greater than the current max, update max
            if (n > max)
            {
                max = n;
            }
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}
