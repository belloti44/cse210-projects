using System;
using System.Collections.Generic;
using System.IO;

class Program 
{
     static void Main() 
     {
        Journal journal = new Journal();
        while (true)
         {
             Console.WriteLine("\nJournal Menu:");
             Console.WriteLine("1. Write a new entry");
             Console.WriteLine("2. Display the journal");
             Console.WriteLine("3. Save journal to file");
             Console.WriteLine("4. Load journal from file");
             Console.WriteLine("5. Exit");
             Console.Write("Select an option: ");

            string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                journal.WriteEntry();
                break;
            case "2":
                journal.DisplayJournal();
                break;
            case "3":
                journal.SaveJournalToFile();
                break;
            case "4":
                journal.LoadJournalFromFile();
                break;
            case "5":
                return;
            default:
                Console.WriteLine("Invalid option, please try again.");
                break;
        }
    }
}

}

class Journal
{ 
    private List<Entry> entries = new List<Entry>(); 
    private List<string> prompts = new List<string> { "Who was the most interesting person I interacted with today?", "What was the best part of my day?", "How did I see the hand of the Lord in my life today?", "What was the strongest emotion I felt today?", "If I had one thing I could do over today, what would it be?"
     };

public void WriteEntry()
{
    Random rand = new Random();
    string prompt = prompts[rand.Next(prompts.Count)];
    Console.WriteLine("\nPrompt: " + prompt);
    Console.Write("Your response: ");
    string response = Console.ReadLine();
    entries.Add(new Entry(DateTime.Now.ToString("yyyy-MM-dd"), prompt, response));
    Console.WriteLine("Entry saved!\n");
}

public void DisplayJournal()
{
    if (entries.Count == 0)
    {
        Console.WriteLine("No journal entries found.");
        return;
    }
    Console.WriteLine("\nJournal Entries:");
    foreach (var entry in entries)
    {
        Console.WriteLine($"Date: {entry.Date}\nPrompt: {entry.Prompt}\nResponse: {entry.Response}\n");
    }
}

public void SaveJournalToFile()
{
    Console.Write("Enter filename to save: ");
    string filename = Console.ReadLine();
    using (StreamWriter writer = new StreamWriter(filename))
    {
        foreach (var entry in entries)
        {
            writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
        }
    }
    Console.WriteLine("Journal saved successfully!");
}

public void LoadJournalFromFile()
{
    Console.Write("Enter filename to load: ");
    string filename = Console.ReadLine();
    if (!File.Exists(filename))
    {
        Console.WriteLine("File not found.");
        return;
    }
    entries.Clear();
    using (StreamReader reader = new StreamReader(filename))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                entries.Add(new Entry(parts[0], parts[1], parts[2]));
            }
        }
    }
    Console.WriteLine("Journal loaded successfully!");
}

}

class Entry { public string Date { get; } public string Prompt { get; } public string Response { get; }

public Entry(string date, string prompt, string response)
{
    Date = date;
    Prompt = prompt;
    Response = response;
}

}