using API.Models;

namespace API
{
    public interface IUsageDataProvider
    {
        public IEnumerable<ProcessedUsageData> GetUsageData();
    }
}