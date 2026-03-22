using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // Constructor: takes a reference and the full text of the scripture
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // This will split the text into individual words
        string[] parts = text.Split(" ");

        // This will create a Word object for each piece
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    // Hides a specified number of random visible words rather than just the first few
    public void HideRandomWords(int numberToHide)
    {
        // This will build a list of only the visible words left to hide
        List<Word> visibleWords = new List<Word>();

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        // If no visible words remain, stop
        if (visibleWords.Count == 0)
        {
            return;
        }

        Random rand = new Random();

        // Hide up to the requested number, but not more than what's available
        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index); //This will Prevent hiding the same word twice
        }
    }


    public string GetDisplayText()
    {
        // This will Start with the reference
        string result = _reference.GetDisplayText() + "\n\n";

        // Add each word's display text
        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }

        return result.TrimEnd();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}
