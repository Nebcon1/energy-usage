using API.Models;
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
    public IEnumerable<UsageData> Get()
    {
        List<UsageData> energyUsage = new List<UsageData>(){new UsageData(){dateTime = DateTime.Now, EnergyConsumption = 1.2}};
        return energyUsage; 
    }
}
