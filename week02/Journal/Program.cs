// Extra features I added:
// Autosave: Every time a new entry is written, the journal
// automatically saves to "autosave.txt" so nothing gets lost.
// Autoload: When the program starts, it checks for the autosave
// file and loads it so the user can continue right where they left off.
// Error handling: Saving and loading are wrapped in try/catch blocks
// to prevent crashes from missing files or bad data.

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        // This part is the AUTOLOAD FEATURE and load autosave file if it exists
        if (File.Exists("autosave.txt"))
        {
            journal.LoadFromFile("autosave.txt");
            Console.WriteLine("Autosave loaded.\n");
        }

        bool running = true;

        while (running)
        {
            Console.WriteLine("Please choose one of the following options:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Load the journal");
            Console.WriteLine("4. Save the journal");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // 1. This will generate a random prompt
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);

                    // 2. This will get the user's response
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    // 3. This will get the current date
                    DateTime currentTime = DateTime.Now;
                    string dateText = currentTime.ToShortDateString();

                    // 4. This will create a new Entry object
                    Entry newEntry = new Entry();
                    newEntry._date = dateText;
                    newEntry._promptText = prompt;
                    newEntry._entryText = response;

                    // 5. This will add it to the journal
                    journal.AddEntry(newEntry);

                    // This is the AUTOSAVE FEATURE — saves automatically after every new entry
                    journal.SaveToFile("autosave.txt");

                    Console.WriteLine("Entry added and autosaved!\n");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
