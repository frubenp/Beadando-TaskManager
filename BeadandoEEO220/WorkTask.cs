public class WorkTask : Task
{
    public string ProjectName { get; set; }

    public override void PrintDetails()
    {
        base.PrintDetails();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"Project: {ProjectName}");
        Console.ResetColor();
    }
}