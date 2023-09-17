using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class EnergyDataController : ControllerBase
{
    private readonly ILogger<EnergyDataController> _logger;
    private IUsageRepository _usageRepository;

    public EnergyDataController(ILogger<EnergyDataController> logger, IUsageRepository usageRepository)
    {
        _logger = logger;
        _usageRepository = usageRepository;
    }

    [HttpGet(Name = "GetUsageData")]
    public IEnumerable<UsageData> Get()
    {
        return _usageRepository.GetUsageData();
        // List<UsageData> energyUsage = new List<UsageData>(){new UsageData(){dateTime = DateTime.Now, EnergyConsumption = 1.2}};
        // return energyUsage;
    }
}
