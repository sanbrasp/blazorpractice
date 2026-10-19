using BlazorCrashCourse.Models;

namespace BlazorCrashCourse.Services;

public class ProductService(HttpClient http)
{
    private readonly List<Product> _products = new();
    public IReadOnlyList<Product> GetAll() => _products;
    public Product? GetById(int id) => _products.FirstOrDefault(x => x.Id == id);
    
    public async Task<List<Product>?> GetProductAsync() 
        => await http.GetFromJsonAsync<List<Product>>("products");

    public async Task<Product?> AddAsync(Product p)
    {
        var response = await http.PostAsJsonAsync("products", p);
        
        return await response.Content.ReadFromJsonAsync<Product>();
    }
    
    public async Task UpdateAsync(Product p)
    => await http.PutAsJsonAsync($"products/{p.Id}", p);
    
    public async Task DeleteAsync(int id)
    => await http.DeleteAsync($"products/{id}");
    
    
    
    
    
    // Older
    
    // {
    //     new() { Id = 1, Name = "Banana", Price = 22.4m, Emoji = "🍌", Description = "A basic banana." },
    //     new() { Id = 2, Name = "Milk", Price = 39.9m, Emoji = "🥛", Description = "Cold and sweet." },
    //     new() { Id = 3, Name = "Potato", Price = 15.0m, Emoji = "🥔", Description = "All hail Potato." }
    // };
}