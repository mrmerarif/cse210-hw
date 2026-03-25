//This class is responsible for one video and its comments.

using System;
using System.Collections.Generic;

public class Video
{
    private string _title; // Private field to store the title of the video
    private string _author; // Storing the name of the author of the video
    private int _lengthInSeconds; // Storing the length of the video in seconds
    private List<Comment> _comments = new List<Comment>(); // A list to hold the comments associated with the video

    public Video(string title, string author, int lengthInSeconds) // Constructor when you create a video and initialize it shows the title, author, and length of the video
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
    }

    public void AddComment(Comment comment) // Method to add a comment to the video. It takes a Comment object as a parameter and adds it to the _comments list.
    {
        _comments.Add(comment);
    }

    public int GetCommentCount() // Method to get the number of comments on the video.
    {
        return _comments.Count;
    }

    public void DisplayFullDetails()
    {
        Console.WriteLine($"Title:  {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_lengthInSeconds} seconds");
        Console.WriteLine($"Number of comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");

        foreach (Comment comment in _comments)
        {
            Console.WriteLine($"  - {comment.GetDisplayText()}");
        }

        Console.WriteLine();
    }
}
