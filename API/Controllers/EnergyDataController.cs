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
    public IEnumerable<ProcessedUsageData> Get()
    {
        return _usageRepository.GetUsageData();
    }
}
