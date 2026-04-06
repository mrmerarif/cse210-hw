// I added two small improvements to make the program feel more useful. First, the app now keeps a simple session log so each activity that is finish gets saved with a timestamp.  
// Second, I added a menu option that lets you read that log inside the program, so you can look back at what you've done.


using System;
using System.IO;  // Added for file handling to read the session log when the user selects the option to view it

class Program
{
    static void Main(string[] args)  // Main method to run the mindfulness program, which displays a menu and allows the user to select different activities or view their session log
    {
        bool running = true;  // Variable to control the main loop of the program, allowing it to continue running until the user chooses to quit

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. View Session Log");  // <-- NEW: Added menu option to view the session log
            Console.WriteLine("5. Quit");
            Console.Write("\nSelect a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice) // Switch statement to handle the user's menu selection and run the corresponding activity or view the session log
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    break;

                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    break;

                case "4":
                    ViewLog();   // <-- NEW
                    break;

                case "5":
                    Console.WriteLine("\nThank you for using the Mindfulness Program.");
                    running = false;
                    break;

                default:
                    Console.WriteLine("\nInvalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }


    //this is the enhancement to create a method to view the session log, which reads from the log file and displays its contents to the user

    static void ViewLog()
    {
        Console.Clear();
        Console.WriteLine("Session Log");
        Console.WriteLine("-----------\n");

        if (File.Exists("session_log.txt"))  // Check if the log file exists before trying to read it
        {
            string[] lines = File.ReadAllLines("session_log.txt"); // Read all lines from the log file into an array of strings

            if (lines.Length == 0) // Check if the log file is empty and display a message if it is 
            {
                Console.WriteLine("The log is currently empty.\n");
            }
            else
            {
                foreach (string line in lines) // Loop through each line in the log file and display it to the user
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No log file found yet.\n");
        }

        Console.WriteLine("Press Enter to return to the menu...");
        Console.ReadLine();
    }
}
