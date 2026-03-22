// Enhancement: Improved hiding logic
// I added an enhancement so the program only picks from words that are still visible.
// This prevents the program from choosing words that were already hidden.
// It now hides exactly the number of words requested, never hides the same word twice,
// and finishes cleanly when no visible words remain.

//Enhancement: Added file loading
// I added functionality to load scriptures from a text file instead of hardcoding them.
// The program now reads all scriptures from a file and randomly selects one to display.

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // This load all scriptures from the scripture.txt file
        List<Scripture> library = LoadScripturesFromFile("scriptures.txt");

        // This checks if any scriptures were loaded from the file
        if (library.Count == 0)
        {
            Console.WriteLine("No scriptures were loaded. Please check the file.");
            return;
        }

        // This will pick a random scripture from the library
        Random rand = new Random();
        Scripture scripture = library[rand.Next(library.Count)];

        // This loop will continue until the user types "quit" or all words are hidden
        bool done = false;


        while (!done)
        {
            Console.Clear();

            Console.WriteLine("Scripture Memorizer");
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to finish: ");

            string input = Console.ReadLine();

            if (input == "quit")
            {
                done = true;
            }
            else
            {
                scripture.HideRandomWords(3);

                if (scripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine(scripture.GetDisplayText());
                    done = true;
                }
            }
        }
    }


    // This will loads the scriptures from a text file
    // the format is per line, using: Book|Chapter|Verse or Verse-Range|Text

    static List<Scripture> LoadScripturesFromFile(string filename)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"File not found: {filename}");
            return scriptures;
        }

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] parts = line.Split("|");

            if (parts.Length < 4)
                continue;

            string book = parts[0].Trim();
            int chapter = int.Parse(parts[1].Trim());
            string versePart = parts[2].Trim();
            string text = parts[3].Trim();

            Reference reference;

            // Check if verse is a range (e.g., "8-9")
            if (versePart.Contains("-"))
            {
                string[] range = versePart.Split("-");
                int startVerse = int.Parse(range[0]);
                int endVerse = int.Parse(range[1]);
                reference = new Reference(book, chapter, startVerse, endVerse);
            }
            else
            {
                int verse = int.Parse(versePart);
                reference = new Reference(book, chapter, verse);
            }

            scriptures.Add(new Scripture(reference, text));
        }

        return scriptures;
    }
}
