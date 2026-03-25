using System;
using System.Collections.Generic; // We need this to use List<T>

class Program // This is the main class that will run our program. It contains the Main method, which is the entry point of the application.
{
    static void Main(string[] args) // The Main method is where the program starts executing. It creates videos, adds comments to them, and displays their details.
    {
        // We create a list to hold our Video objects. This allows us to manage multiple videos and their associated comments easily.
        List<Video> videos = new List<Video>();

        // -- Video 1 
        Video video1 = new Video("Scripture Study Tips", "Faithful Living", 300);
        video1.AddComment(new Comment("Alice", "This really helped my study today."));
        video1.AddComment(new Comment("Ben", "I love these ideas, thank you!"));
        video1.AddComment(new Comment("Sofia", "I’m going to try this with my family."));
        videos.Add(video1);

        // -- Video 2 
        Video video2 = new Video("How to Memorize Scriptures", "Gospel Tools", 420);
        video2.AddComment(new Comment("David", "The repetition method works great."));
        video2.AddComment(new Comment("Maria", "I appreciate the practical examples."));
        video2.AddComment(new Comment("Leo", "Can you do one on hymns too?"));
        videos.Add(video2);

        // -- Video 3
        Video video3 = new Video("Peace in Christ", "Music Channel", 260);
        video3.AddComment(new Comment("Emma", "This song brings me so much peace."));
        video3.AddComment(new Comment("Noah", "Listening to this on repeat."));
        video3.AddComment(new Comment("Luz", "Beautiful message and arrangement."));
        videos.Add(video3);

        // -- Video 4 --
        Video video4 = new Video("Come Follow Me Insights", "Study Group", 540);
        video4.AddComment(new Comment("Hannah", "This helped me understand the chapter better."));
        video4.AddComment(new Comment("Carlos", "I like how you explain the context."));
        video4.AddComment(new Comment("Jade", "Please keep making these videos!"));
        videos.Add(video4);

        // Now loop through each video and display its details
        foreach (Video video in videos)
        {
            video.DisplayFullDetails();
        }
    }
}
