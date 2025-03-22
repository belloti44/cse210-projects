using System;

class Program
{
    static void Main(string[] args)
    {
         // Prompt for first name
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();

        // Prompt for last name
        Console.Write("Enter your last name: ");
        string lastName = Console.ReadLine();

        // Display the output
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}");

        
    }
}