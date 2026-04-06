using System;

class Program
{
    static void Main(string[] args)
    {
        // Test the base class
        Assignment a1 = new Assignment("Hugo Sanchez", "Multiplication");
        Console.WriteLine(a1.GetSummary());
        Console.WriteLine();

        // Test the MathAssignment class
        MathAssignment m1 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(m1.GetSummary());
        Console.WriteLine(m1.GetHomeworkList());
        Console.WriteLine();

        // Test the WritingAssignment class
        WritingAssignment w1 = new WritingAssignment("Mary Hernandez", "European History", "The French Revolution");
        Console.WriteLine(w1.GetSummary());
        Console.WriteLine(w1.GetWritingInformation());
    }
}
