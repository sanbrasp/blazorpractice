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
- `@ notation` C# syntax practice

---

## Pages
- `/practice`: bind, events, conditionals
- `/todos`: todo list using `TodoServices` and the `TodoRow` component

---

## Run
Requires .NET 10 SDK (developed in JetBrains Rider).

```
dotnet run
```

Data is held in memory only and resets on restart or refresh.


---