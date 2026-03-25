//this class is responsible for 1 comment.
using System;


//The comment class represents a comment on a YouTube video. It has two private fields: _name and _text, which store the name of the commenter and the text of the comment, respectively. The constructor initializes these fields, and the GetDisplayText method returns a formatted string that combines the name and text for display purposes.
public class Comment
{
    private string _name; // Private field to store the name of the commenter
    private string _text; // Private field to store the text of the comment

    public Comment(string name, string text) // This is a constructor. When you create a new Comment, you pass in the name and text, and it saves them into the private variables.
    {
        _name = name;
        _text = text;
    }

    public string GetDisplayText() // This method returns a string that combines the name and text of the comment for display purposes.
    {
        return $"{_name}: {_text}";
    }
}
