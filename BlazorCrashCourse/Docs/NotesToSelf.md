# Notes To Self
Various notes regarding Blazor during the practice project.

---

## Contents
- [Terminology](#terminology)
  - [Blazor and .razor](#separating-blazor-from-razor)
  - [Parent VS Child](#parent-vs-child)
- [Concept](#concept)

---

## Terminology

### Separating Blazor from .razor

| Name   | What it is                                                                                                                             |
|--------|----------------------------------------------------------------------------------------------------------------------------------------|
| Blazor | The framework. Runs components, handles events, re-renders UI, manages connection between server and browser                           |
| Razor  | The Markup syntax. Lets you mix HTML and C# using `@`. It is older than Blazor and also used in ASP.NET MVC and Razor Pages (`.cshtml` |
| .razor | The file extension for Blazor components written in Razor syntax. Compiled into a C# class.                                            |

---

### Parent VS Child
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