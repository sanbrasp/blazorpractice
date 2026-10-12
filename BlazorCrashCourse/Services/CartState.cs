namespace BlazorCrashCourse.Services;

internal class CartState
{
    public int Count  { get; private set; }

    public event Action? OnChange;

    public void Add()
    {
        Count++;
        OnChange?.Invoke();
    }
}