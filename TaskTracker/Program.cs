using TaskTracker;

List<TaskTracker.Task> tasks = [];
TaskService taskService = new(tasks);

Console.WriteLine("#### Taks Tracker: ####");

int n;
while (true)
{
    Console.WriteLine("1. Create New Task:");
    Console.WriteLine("2. Delete New Task:");
    Console.WriteLine("3. Update New Task:");
    Console.WriteLine("4. List all tasks:");
    do 
    {
        Console.Write("Choose your operation: ");
        try
        {
            n = int.Parse(Console.ReadLine());
        }catch
        {
            System.Console.WriteLine("Type valid number between 1 and 4!:");
            n = 0;
        }
    } while(n < 1 || n > 4);

    string? Title;
    switch (n)
    {
        case 1:
            System.Console.Write("Task title: ");
            Title = Console.ReadLine();
            if (Title != null)
            {
                taskService.AddTask(Title);
            }
            System.Console.WriteLine("Task added successfully!");
            break;
        
        case 2:
            tasks = taskService.AllTasks();
            foreach (var task in tasks)
            {
                Console.WriteLine(task.Id + "- "+task.Title + " --> " + (task.IsDone == false ? "On progress": "Done"));
            }
            do 
            {
                try
                {
                    Console.Write("Choose a task to delete: ");
                    n = int.Parse(Console.ReadLine());
                }catch
                {
                    System.Console.WriteLine("Type valid number between 1 and 4!:");
                    n = 0;
                }
            } while(n < 1 || n > tasks.Count);
            taskService.DeleteTask(n);
            System.Console.WriteLine("Task deleted successfully!");
            break;

        case 3:
            tasks = taskService.AllTasks();
            foreach (var task in tasks)
            {
                Console.WriteLine(task.Id + "- "+task.Title + " --> " + (task.IsDone == false ? "On progress": "Done"));
            }
            while (true)
            {
                do 
                {
                    try
                    {
                        Console.Write("Choose a task to update: ");
                        n = int.Parse(Console.ReadLine());
                    }catch
                    {
                        System.Console.WriteLine($"Type valid number between 1 and {tasks[tasks.Count - 1].Id}!");
                        n = 0;
                    }
                } while(n < 1 || n > tasks[tasks.Count - 1].Id);
                Console.WriteLine("\t 1. Update Title:");
                Console.WriteLine("\t 2. Update Status:");
                int i;
                do 
                {
                    try
                    {
                        Console.Write("Choose what to update: ");
                        i = int.Parse(Console.ReadLine());
                    }catch
                    {
                        System.Console.WriteLine($"Choose valid number 1 or 2!");
                        i = 0;
                    }
                } while(i != 1 && i != 2);

                if(i == 1){
                    System.Console.Write("Enter the new title: ");
                    System.Console.WriteLine(n);
                    Title = Console.ReadLine();
                    if(Title != null){
                        taskService.UpdateTaskTitle(n, Title);
                        System.Console.WriteLine("Task updated successfully!");
                        break;
                    }
                }
                else 
                {
                    Console.WriteLine("\t\t 1. Check Done");
                    Console.WriteLine("\t\t 2. Uncheck Done");
                    do 
                    {
                        try
                        {
                            Console.Write("Check or uncheck Done to task: ");
                            i = int.Parse(Console.ReadLine());
                        }catch
                        {
                            System.Console.WriteLine($"Choose valid number 1 or 2!");
                            i = 0;
                        }
                    } while(i != 1 && i != 2);
                }
                if(i == 1)
                {
                   taskService.TaskIsDone(n, true);
                }else
                {
                    taskService.TaskIsDone(n, false);
                }
                System.Console.WriteLine("Task updated successfully!");
                break;
            }
            break;

        case 4:
            tasks = taskService.AllTasks();
            if(tasks.Count == 0)
            {
                System.Console.WriteLine("No task added yet!");
                break;
            }
            foreach (var task in tasks)
            {
                Console.WriteLine(task.Id + "- "+task.Title + " --> " + (task.IsDone == false ? "On progress": "Done"));
            }
            break;
        
        default:
            break;
    }

    System.Console.WriteLine("Type 0 to return to menu Or E/Exit to exit");
    string exit = Console.ReadLine();
    if(exit == "Exit" || exit == "E")
    {
        return;
    }
}
