using API.Models;

namespace API
{
    public interface IUsageRepository
    {
        public IEnumerable<ProcessedUsageData> GetUsageData();
    }
}