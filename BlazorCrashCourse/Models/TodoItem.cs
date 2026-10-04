namespace BlazorCrashCourse.Models;

public class TodoItem
{
    public int Id { get; init; }
    public string Title { get; init; } = "";
    public bool IsDone { get; private set; }
    
    public void SetDone(bool done) => IsDone = done;
}