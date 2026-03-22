public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    // Constructor for a single verse (e.g., John 17:3)
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = 0; // 0 means "no range"
    }

    // Constructor for a verse range (e.g., John 17:3–4)
    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    // Returns "John 17:3" or "John 17:3–4"
    public string GetDisplayText()
    {
        if (_endVerse == 0)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}

