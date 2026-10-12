namespace BlazorCrashCourse.Services;

internal class CartState
{
    public int Count  { get; private set; }

    public event Action? OnChange; // the bell!

    public void Add()
    {
        Count++;
        OnChange?.Invoke(); // ring the bell!
    }
}