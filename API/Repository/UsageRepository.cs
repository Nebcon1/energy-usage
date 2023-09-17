using API.Models;

namespace API
{
    public class UsageRepository : IUsageRepository
    {
        public IEnumerable<ProcessedUsageData> GetUsageData()
        {
            List<ProcessedUsageData> energyUsage = new List<ProcessedUsageData>(){new ProcessedUsageData(){dateTime = DateTime.Now, EnergyConsumption = 1.2}};
            return energyUsage;
        }
    }
}