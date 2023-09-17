using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class EnergyDataController : ControllerBase
{
    private readonly ILogger<EnergyDataController> _logger;

    public EnergyDataController(ILogger<EnergyDataController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetUsageData")]
    public string Get()
    {
        return "test";
    }
}
