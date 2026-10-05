# Software Design with Blazor
Basic intro practice

---

Intro practice to `Software Design with Blazor`.  
AI assisted:  
`Claude.ai` was instructed to generate a basic crash course for Blazor basics with explanations for concepts
and debugging assistance.  
`Claude.ai` also cleaned up and organized the initial README, but the contents are mine.

---

## Covers
- Basic bind, one-way and two-way (`@bind`, `@bind:event="oninput"`)
- Event handlers (`@onclick`, `@onchange`, `@onkeydown`)
- Conditional rendering and loops (`@if`, `@foreach`)
- Basic Components and Pages
- Component parameters (`[Parameter]`) and `EventCallback`
- Dependency injection (`@inject`, `AddScoped`)
- Separation of concerns: `Models/`, `Services/` and UI
- Encapsulation (`init` and `private set`)
- Scoped CSS (`Component.razor.css`) and global styles (`wwwroot/app.css`)
- `@ notation` C# syntax practice

---

## Pages
- `/practice`: bind, events, conditionals
- `/todos`: todo list using `TodoServices` and the `TodoRow` component
- `/theme`: light/dark toggle using the `ThemeCard` component and a `[Parameter]`
- `/shop`: product list using `ProductService` and the `ProductCard` component with an `OnAdd` callback
- `/product/{Id:int}`: product details with a "not found" state

---

## Run
Requires .NET 10 SDK (developed in JetBrains Rider).

```
dotnet run
```

Run it from the project folder (containing `.csproj`).  
Data is held in memory only and resets on restart or refresh.


---