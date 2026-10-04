using BlazorCrashCourse.Models;

namespace BlazorCrashCourse.Services;

public class TodoServices
{
    private readonly List<TodoItem> _items = new();
    private int _nextId = 1;
    
    // Return read-only view
    public IReadOnlyList<TodoItem> GetAll() => _items;

    public void Add(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return;
        _items.Add(new TodoItem { Id = _nextId++, Title = title.Trim() });
    }

    public void Remove(int id)
    {
        _items.RemoveAll(i => i.Id == id);
    }
}