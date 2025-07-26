# Puzzle #86 - Unexpected 404

Carl and Jeff want to know why this API call isn't working in production (Azure Web Apps)

YouTube Video: https://youtu.be/1uiLkNFRwM4

Blazor Puzzle Home Page: https://blazorpuzzle.com

## The Challenge

This is a .NET 9 Blazor Web App with Global WebAssembly interactivity.

We are attempting to call an API endpoint passing a login string that includes a backslash (\\).

It only works locally if we escape the backslash, but it does not work in production on Azure.

How can we fix it so that it works both locally and in production?

## The Solution

The solutions is to use the "greedy" operator in the API route:

```c#
[Route("[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet("{**Login}")]
    public async Task<IActionResult> Get(string Login, [FromQuery] string AnotherParameter)
    {
        return new OkObjectResult($"Test successful - {Login}, {AnotherParameter}");
    }
}
```

This operator tells ASP.NET Core to grab every character from the Login parameter all the way to the question mark and consider that the parameter.

A constraint applies here, though. It has to be the last route parameter specified. Therefore, we have to change `AnotherParameter` to be a query parameter.

Here's how we call it:

```c#
string login = "mydomain\\myuser";
login = Uri.EscapeDataString(login);

var response = await _httpClient.GetAsync($"test/{login}?AnotherParameter=foo");

// we are getting a 404 (Not found error)
if (response.StatusCode != System.Net.HttpStatusCode.OK)
{
    StatusCode = $"Result: {response.StatusCode}";
}
else
{
    var msg = await response.Content.ReadAsStringAsync();
    StatusCode = $"Result: {msg}";
}
```

It works locally AND in production.

Boom!
