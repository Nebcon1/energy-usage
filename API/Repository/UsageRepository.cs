using API.Models;

namespace API
{
    public class UsageRepository : IUsageRepository
    {
        public IEnumerable<UsageData> GetUsageData()
        {
            List<UsageData> energyUsage = new List<UsageData>(){new UsageData(){dateTime = DateTime.Now, EnergyConsumption = 1.2}};
            return energyUsage;
        }
    }
}