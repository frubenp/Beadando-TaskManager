using System.Buffers;

public class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; private set; }

    public virtual void PrintDetails()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Title: {Title}, Description: {Description}");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Completed: {IsCompleted}");
        Console.ResetColor();
    }

    public void MarkComplete()
    {
        IsCompleted = true;
    }
}
