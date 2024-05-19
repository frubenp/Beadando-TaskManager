namespace BeadandoEEO220
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager<WorkTask> workTaskManager = new TaskManager<WorkTask>();
            TaskManager<PersonalTask> personalTaskManager = new TaskManager<PersonalTask>();

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("========================");
                    Console.WriteLine("    Task Management     ");
                    Console.WriteLine("========================");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("1. Add Work Task");
                    Console.WriteLine("2. Add Personal Task");
                    Console.WriteLine("3. List All Tasks");
                    Console.WriteLine("4. Complete Task");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("5. Exit");
                    Console.ResetColor();
                    Console.WriteLine("========================");
                    Console.Write("Select an option: ");

                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            AddWorkTask(workTaskManager);
                            break;
                        case "2":
                            AddPersonalTask(personalTaskManager);
                            break;
                        case "3":
                            ListAllTasks(workTaskManager, personalTaskManager);
                            break;
                        case "4":
                            CompleteTask(workTaskManager, personalTaskManager);
                            break;
                        case "5":
                            return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid option. Press any key to continue...");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    Console.ResetColor();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        static void AddWorkTask(TaskManager<WorkTask> workTaskManager)
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("========================");
                Console.WriteLine("    Add Work Task       ");
                Console.WriteLine("========================");
                Console.Write("Title: ");
                string title = Console.ReadLine();
                Console.Write("Description: ");
                string description = Console.ReadLine();
                Console.Write("Project Name: ");
                string projectName = Console.ReadLine();
                Console.ResetColor();

                WorkTask workTask = new WorkTask
                {
                    Title = title,
                    Description = description,
                    ProjectName = projectName
                };

                workTaskManager.AddTask(workTask);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Work task added successfully!");
                Console.ResetColor();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred while adding the work task: {ex.Message}");
                Console.ResetColor();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void AddPersonalTask(TaskManager<PersonalTask> personalTaskManager)
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("========================");
                Console.WriteLine("  Add Personal Task     ");
                Console.WriteLine("========================");
                Console.Write("Title: ");
                string title = Console.ReadLine();
                Console.Write("Description: ");
                string description = Console.ReadLine();
                Console.Write("Due Date (yyyy-mm-dd): ");
                DateTime dueDate;
                Console.ResetColor();
                while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Invalid date format. Please enter again (yyyy-mm-dd): ");
                    Console.ResetColor ();
                }

                PersonalTask personalTask = new PersonalTask
                {
                    Title = title,
                    Description = description,
                    DueDate = dueDate
                };

                personalTaskManager.AddTask(personalTask);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Personal task added successfully!");
                Console.ResetColor();
                    Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred while adding the personal task: {ex.Message}");
                Console.ResetColor();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void ListAllTasks(TaskManager<WorkTask> workTaskManager, TaskManager<PersonalTask> personalTaskManager)
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("========================");
                Console.WriteLine("      All Tasks         ");
                Console.WriteLine("========================");
                Console.WriteLine("Work Tasks:");
                workTaskManager.ListTasks();
                Console.WriteLine("\nPersonal Tasks:");
                personalTaskManager.ListTasks();
                Console.WriteLine("========================");
                Console.ResetColor();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred while listing the tasks: {ex.Message}");
                Console.ResetColor();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void CompleteTask(TaskManager<WorkTask> workTaskManager, TaskManager<PersonalTask> personalTaskManager)
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("========================");
                Console.WriteLine("    Complete Task       ");
                Console.WriteLine("========================");
                Console.Write("Enter the title of the task to complete: ");
                Console.ResetColor();
                string title = Console.ReadLine();

                try
                {
                    workTaskManager.CompleteTask(title);
                    personalTaskManager.CompleteTask(title);
                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred while completing the task: {ex.Message}");
                Console.ResetColor();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}