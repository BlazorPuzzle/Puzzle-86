﻿namespace Puzzle86.Controllers;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
public class TestController : ControllerBase
{
	[HttpGet("{Login}/{AnotherParameter}")]
	public async Task<IActionResult> Get(string Login, string AnotherParameter)
	{
		return new OkObjectResult($"Test successful - {Login}, {AnotherParameter}");
	}
}
