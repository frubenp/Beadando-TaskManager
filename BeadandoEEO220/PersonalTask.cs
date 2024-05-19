public class PersonalTask : Task
{
    public DateTime DueDate { get; set; }

    public override void PrintDetails()
    {
        base.PrintDetails();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Due Date: {DueDate.ToShortDateString()}");
        Console.ResetColor();
    }
}