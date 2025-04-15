namespace TaskTracker;

public class Task(string Title)
{
    private static int _ID = 1;
    public int Id { get; set; } = _ID++;
    public string Title { get; set; } = Title;
    public bool IsDone { get; set; } = false;
}
