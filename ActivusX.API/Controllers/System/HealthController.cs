using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActivusX.API.Controllers.System
{
    [Route("api/System/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private const string ApiKeyHeaderName = "X-API-KEY";
        private const string ApiKey = "your-secure-api-key"; // Replace with your actual API key

        [HttpGet]
        public IActionResult Get()
        {
            if (!Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey))
            {
                return Unauthorized(new { Message = "API Key was not provided." });
            }

            if (!ApiKey.Equals(extractedApiKey))
            {
                return Unauthorized(new { Message = "Unauthorized client." });
            }

            return Ok(new { Message = "Hello, World!" });
        }
    }
}
