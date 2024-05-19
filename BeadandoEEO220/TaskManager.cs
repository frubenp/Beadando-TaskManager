public class TaskManager<T> where T : Task
{
    private List<T> tasks = new List<T>();

    public void AddTask(T task)
    {
        tasks.Add(task);
    }

    public void RemoveTask(T task)
    {
        tasks.Remove(task);
    }

    public void ListTasks()
    {
        foreach (var task in tasks)
        {
            task.PrintDetails();
            Console.WriteLine("---------------------");
        }
    }

    public void CompleteTask(string title)
    {
        var task = tasks.Find(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (task != null)
        {
            task.MarkComplete();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Task marked as complete!");
            Console.ResetColor();
        }
    }
}