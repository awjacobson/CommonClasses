# CommonClasses
## Name
## PhoneNumber
## State
The following is an example of how to use State to create a droplist in an ASP.NET Core and Razor:

### HomeController.cs
```
private static SelectList GetStateList()
{
    var states = new States().OrderBy(x => x.LongName);
    var selectList = new SelectList(new[] { new { value = "", text = "" }}
        .Concat(states.Select(x => new { value = x.ShortName, text = x.LongName })), "value", "text");
    return selectList; 
}
```

### Create.cshtml
```
<select asp-for="State" asp-items="@Model.StateList" class="form-control"></select>
```