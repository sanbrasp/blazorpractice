using BlazorCrashCourse.Models;

namespace BlazorCrashCourse.Services;

public class ProductService
{
    private readonly List<Product> _products = new()
    {
        new() { Id = 1, Name = "Banana", Price = 22.4m, Emoji = "🍌", Description = "A basic banana." },
        new() { Id = 2, Name = "Milk", Price = 39.9m, Emoji = "🥛", Description = "Cold and sweet." },
        new() { Id = 3, Name = "Potato", Price = 15.0m, Emoji = "🥔", Description = "All hail Potato." }
    };
    
    public IReadOnlyList<Product> GetAll() => _products;
    public Product? GetById(int id) => _products.FirstOrDefault(x => x.Id == id);
}