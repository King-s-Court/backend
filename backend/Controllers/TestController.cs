using Microsoft.AspNetCore.Mvc;
using common.models;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult GetFEN()
    {
        string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w - 0 1";
        return Ok(fen);

    }
}