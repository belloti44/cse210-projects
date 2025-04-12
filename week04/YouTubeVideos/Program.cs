using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        CommenterName = name;
        Text = text;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }

    private List<Comment> _comments = new List<Comment>();

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // First video
        Video video1 = new Video { Title = "Top 10 Productivity Hacks", Author = "Ali Abdaal", LengthInSeconds = 600 };
        video1.AddComment(new Comment("James", "Super helpful tips!"));
        video1.AddComment(new Comment("Lilly", "Loved tip #3!"));
        video1.AddComment(new Comment("Marcus", "Saving this for later."));
        videos.Add(video1);

        // Second video
        Video video2 = new Video { Title = "How to Cook the Perfect Steak", Author = "Gordon Ramsay", LengthInSeconds = 450 };
        video2.AddComment(new Comment("Laura", "Now I’m hungry..."));
        video2.AddComment(new Comment("Tom", "That sear was perfect."));
        video2.AddComment(new Comment("Sarah", "Tried it—came out great!"));
        videos.Add(video2);

        // Third video
        Video video3 = new Video { Title = "Beginner's Guide to Python", Author = "Tech With Tim", LengthInSeconds = 900 };
        video3.AddComment(new Comment("John", "Explained so well!"));
        video3.AddComment(new Comment("Amy", "Very helpful for my class."));
        video3.AddComment(new Comment("Daniel", "Thanks for the clarity."));
        videos.Add(video3);

        // Fourth video
        Video video4 = new Video { Title = "Morning Workout Routine", Author = "FitnessBlender", LengthInSeconds = 720 };
        video4.AddComment(new Comment("Emma", "My new daily routine!"));
        video4.AddComment(new Comment("Chris", "Sweating by minute 5."));
        video4.AddComment(new Comment("Olivia", "Loved it. Short and effective."));
        videos.Add(video4);

        // Display all videos and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}