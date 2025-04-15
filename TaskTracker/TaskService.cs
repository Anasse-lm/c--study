using System;
using System.Reflection;

namespace TaskTracker;

public class TaskService(List<Task> tasks)
{
    private readonly List<Task> tasks = tasks;
    public void AddTask(string Title)
    {
        Task task = new(Title);
        tasks.Add(task);
    }
    public void DeleteTask(int i) 
    {
        tasks.RemoveAt(i - 1);
    }
    public void UpdateTaskTitle(int i, string Title)
    {
        tasks[i - 1].Title = Title;
    }
    public void TaskIsDone(int i, bool IsDone)
    {
        if(tasks[i - 1].IsDone != IsDone)
            tasks[i - 1].IsDone = IsDone;
    }
    public List<Task> AllTasks() {
        return tasks;
    }

}
