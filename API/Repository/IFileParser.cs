using API.Models;

namespace API.Repository
{
    public interface IFileParser
    {
        public IEnumerable<UsageData> ParseUsageData(string filepath);
        public IEnumerable<Anomaly> ParseAnomalies(string filepath);
    }
}