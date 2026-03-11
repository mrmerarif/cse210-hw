using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        // Loop to allow the user to play multiple times
        while (playAgain.ToLower() == "yes")
        {
            // Generate the magic number (1–100)
            Random random = new Random();
            int magicNumber = random.Next(1, 101);

            // Initialize variables for the user's guess and the number of guesses
            int guess = -1;
            // Initialize a counter for the number of guesses
            int guessCount = 0;

            // Loop until the guess matches the magic number
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();
                guess = int.Parse(input);

                // Increment the guess counter
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            Console.Write("Do you want to play again? ");
            playAgain = Console.ReadLine();
            Console.WriteLine();
        }
    }
}
