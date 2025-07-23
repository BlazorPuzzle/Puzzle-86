namespace Puzzle86.Controllers;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
public class TestController : ControllerBase
{
	[HttpGet("{Login}")]
	public async Task<IActionResult> Get(string Login)
	{
		return new OkObjectResult("Test successful");
	}
}
