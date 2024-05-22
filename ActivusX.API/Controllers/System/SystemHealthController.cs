using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActivusX.API.Controllers.System;

[Route("api/[controller]")]
[ApiController]
public class SystemHealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { Message = "Hello, World!" });
    }
}
