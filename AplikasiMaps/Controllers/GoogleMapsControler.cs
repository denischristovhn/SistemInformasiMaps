using Microsoft.AspNetCore.Mvc;

namespace AplikasiMaps.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoogleMapsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<GoogleMapsController> _logger;

        public GoogleMapsController(ILogger<GoogleMapsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetGoogleMaps")]
        public IEnumerable<GoogleMaps> Get()
        {
            return Enumerable.Range(1, 1    ).Select(index => new GoogleMaps
            {
                Nama = "Test"
            })
            .ToArray();
        }
    }
}