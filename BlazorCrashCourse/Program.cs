using BlazorCrashCourse.Components;
using BlazorCrashCourse.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<BlazorCrashCourse.Services.TodoServices>();
builder.Services.AddSingleton<BlazorCrashCourse.Services.ProductService>();
builder.Services.AddScoped<CartState>();
builder.Services.AddHttpClient<ProductService>(c => c.BaseAddress = new Uri("https://fakestoreapi.com"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

// Middle-ware, we will learn about this later
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();