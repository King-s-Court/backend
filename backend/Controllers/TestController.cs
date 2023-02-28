namespace backend.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }
}