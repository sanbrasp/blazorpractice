# Notes To Self
Various notes regarding Blazor during the practice project.

---

## Contents
- [Concept](#concept)
- [Blazor and .razor](#separating-blazor-from-razor)
- [Parent VS Child](#parent-vs-child)
- [Directives and Directive Attributes](#directives-and-directive-attributes)
- [Component Structure](#component-structure)
- [Nested Components and Naming Conventions](#nested-components-and-naming-conventions)

---

## Concept
Blazor, Razor and .razor are three layers of one thing:
- **Blazor** is the engine. It runs your components in the browser/server connection. Reacts to clicks, and re-renders
  the page when data changes.
- **Razor** is the language you write the components in. It lets you put C# inside HTML with `@`.
- **.razor** is the file type where that language lives. One file is one component.

**Analogy:**  
`Blazor` is the game engine. `Razor` is the scripting language. `.razor` is the script file.

**What happens when you run it:**  
The compiler turns each `.razor` file into a C# class. Blazor then runs those classes and updates the page
when their data changes.

This is also why the same Razor syntax appears in older `ASP.NET MVC` (in `.cshtml` files). The syntax is
shared, but only `Blazor` uses `.razor` components.

---

## Separating Blazor from .razor

| Name   | What it is                                                                                                                             |
|--------|----------------------------------------------------------------------------------------------------------------------------------------|
| Blazor | The framework. Runs components, handles events, re-renders UI, manages connection between server and browser                           |
| Razor  | The Markup syntax. Lets you mix HTML and C# using `@`. It is older than Blazor and also used in ASP.NET MVC and Razor Pages (`.cshtml` |
| .razor | The file extension for Blazor components written in Razor syntax. Compiled into a C# class.                                            |

---

## Parent VS Child
A `Parent` is a component that uses another component. The `Child` is the one being used.  

**Example:**  
```razorhtmldialect
@* Shop.razor (parent) *@
<ProductCard Name="Banana" OnAdd="HandleAdd" />
```
**Parent:** `Shop`. It owns the state (i.e., `cartCount`, `lastAdded`) and decides what happens.  
**Child:** `ProductCard`. It displays what it is given, and reports clicks.

**Two Directions:**
```text
Shop (parent)               ProductCard (child)
Name="Banana" -[Parameter]-> shows "Banana"     (data down)
HandleAdd() <-EventCallback- button clicked     (events up)
```
Down: the parent passes data in through `[Parameter]` properties.  
Up: the child can't change the parent's variables. It calls an `EventCallback`, and the parent's method runs.

`ProductCard` knows nothing about `Shop` or the cart. You can reuse it anywhere. Lego brick.  
`Parent` and `Child` describe a relationship, not a type. A page can be a parent, and a child can itself 
be a parent of something smaller.

---

## Directives and Directive Attributes
Razor is a syntax that makes it possible to mix `HTML` and `C#` in the same file. 
The central symbol is `@`, it marks the start of `C# code` or a `directive`.

There are two types of Razor constructions:  
**Directives:** keywords prefixed with `@` that changes how the file is compiled.  
Examples: `@page`, `@using`, `@inject`, `@code`, `@rendermode`.  
**Directive Attributes:** changes how a `HTML` element is compiled.    
Examples: `@bind`, `@onclick`.

**Simple Example - Component with Razor directives:**  
```razorhtmldialect
@page "/doctor-who-episodes/{season:int}"
@rendermode InteractiveWebAssembly
@using System.Globalization
@using Microsoft.AspNetCore.Localization
@attribute [Authorize]
@inject ILogger<DoctorWhoEpisodes> Logger

<PageTitle>Doctor Who Episode List</PageTitle>
```
**Line by line:**  
* `@page` makes the component routable (it can be reached via a URL).
* The segment `{season:int}` is a URL parameter with a type requirement.
* `@rendermode` decides how the component is displayed. `InteractiveWebAssembly`
means the code can be run in the browser.
* `@using` imports namespace, just like in regular C#.
* `@attribute [Authorize]` adds an attribute to the component (here: requires login)
* `@inject` uses Dependency Injection to fetch a service from the DI container.
* `<PageTitle>` is a `Blazor component` that sets the title of the page in the browser.

The recommended order for directives are:  
1. @page
2. @rendermode
3. @using
4. Other directives

---

## Component Structure
Razor components are `C# partial classes` behind the curtain. You can write everything in 
one file (most common), or separate markup and code into two files.  
They both produce the same result.

**Method 1 - One file:**  
The classic counter component from the Blazor. Markup and logic lives together.
```razorhtmldialect
@page "/counter"

<PageTitle>Counter</PageTitle>

<h1>Counter</h1>

<p role="status">Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;
    private void IncrementCount() => currentCount++;
}
```
**It works like this:**  
- `@currentCount` shows the value of the `C# variable` directly in `HTML`
- `@onclick="IncrementCount"` wires the button press to the method `IncrementCount()`
- `@code { ... }` is the block where you define fields, properties, and methods
- When `IncrementCount` runs, Blazor automatically updates the UI because the state variable has
changed. 

**Method 2 - Code-behind:**  
When a component grows, you can move the C# logic to a separate .razor.cs file.  
Example with `CounterPartialClass` component.
```csharp
// CounterPartialClass.razor.cs
namespace BlazorSample.Components.Pages;

public partial class CounterPartialClass
{
    private int currentCount = 0;
    private void IncrementCount() => currentCount++;
}
```
The markup file (`CounterPartialClass.razor`) is identic to the Counter example above, 
but without the `@code` block.  
The filename and class name must be the same.

**Common mistakes:**  
Forgetting the `partial` keyword in the code-behind class.  
Without `partial`, the compiler will complain about double class definitions.

---

## Nested Components and Naming Conventions
Components can be nested, which is one of the strongest features of Blazor.  
One component can contain and use another. This is done with HTML-similar syntax.  
```razorhtmldialect
// Heading.razor
<h1 style="font-style:@headingFontStyle">Heading Example</h1>

@code {
    private string headingFontStyle = "italic";
}

// HeadingExample.razor
@page "/heading-example"

<PageTitle>Heading</PageTitle>

<h1>Heading Example</h1>

<Heading />
```
`<Heading />` is the use of the `Heading.razor` component. Note that the component name 
starts with an upper case letter. This is a requirement in Blazor, and separates components from 
regular HTML elements (lower case)

**Naming Conventions:**  
- File names and class names: Pascal Case -> ProductDetail.razor
- URL-routes: kebab-case -> /product-detail
- Namespace: derived from the root namespace + folder, e.g. `BlazorSample.Components.Page`

These conventions follow Microsoft's recommendations and makes the code easier to read 
and maintain.

---

## Component Design and Responsibility
When a Blazor application grows, it's important to consider component design. 
A good rule of thumb is the `single responsibility principle`: one component, one clear task.

**Signs that a component should be split up:**  
- The component has more than 200-300 lines of code
- It contains logic for display, data input, and user interaction
- Parts of the markup is repeated several times with slightly different parameters

**Naming components:**  
Choose a name that describes _what_ the component does, not _how_.  
A component that shows a user profile can be named `UserProfile`, not `UserDiv`.

**Re-use:**  
Place reusable components in a `Shared/` or `Components/` directory, and ensure they are 
independent of application logic. A `LoadingSpinner` component should not know anything about 
_which_ data is being loaded - it only shows that something is happening.

**Example on bad and good structure:**  
Assume you have a page that lists products and lets the user filter.  
Bad design: one enormous `ProductPage` component with everything.  
Better design: `ProductList`(display), `ProductFilter`(filtering), and 
`ProductCard`(single product) that separates components that are working together 
via parameters and events.

---

