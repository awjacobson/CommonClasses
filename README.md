# Overview

A library of commonly used classes.

# Table of Contents

* [Installation](#installation)
* [Name Class](#name)
* [PhoneNumber Class](#phonenumber)
* [State Class](#state)

<a name="installation"></a>
# Installation

## Prerequisites

- .NET version 4.5.2 and higher
- .NET Core 1.0 and higher
- .NET Standard 1.3 support

## Install Package
```
PM> Install-Package AWJ.CommonClasses
```

<a name="name"></a>
# Name Class

<a name="phonenumber"></a>
# PhoneNumber Class

<a name="state"></a>
# State Class

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