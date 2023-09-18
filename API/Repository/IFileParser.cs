using API.Models;

namespace API.Repository
{
    public interface IFileParser<T>
    {
        // public IEnumerable<UsageData> ParseUsageData(string filepath);
        // public IEnumerable<Anomaly> ParseAnomalies(string filepath);
        public IEnumerable<T> ParseFile(string filepath);

    }
}