namespace BlazorCrashCourse.Models;

public class Product
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
    public string Description { get; init; } = "";
    public decimal Price { get; init; }
    public string Category { get; init; } = "";
    public string Emoji { get; init; } = "📦";
    public Rating Rating { get; set; }
}

public class Rating
{
    public int Rate { get; set; }
    public int Count { get; set; }
}