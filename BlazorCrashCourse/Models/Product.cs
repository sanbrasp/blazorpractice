namespace BlazorCrashCourse.Models;

public class Product
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
    public string Description { get; init; } = "";
    public decimal Price { get; init; }
    public string Emoji { get; init; } = "📦";
}