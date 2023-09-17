using API.Models;

namespace API
{
    public interface IUsageRepository
    {
        public IEnumerable<UsageData> GetUsageData();
    }
}