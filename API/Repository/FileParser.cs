using API.Models;

namespace API.Repository
{
    public class FileParser : IFileParser
    {
        public IEnumerable<Anomaly> ParseAnomalies(string filepath)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsageData> ParseUsageData(string filepath)
        {
            throw new NotImplementedException();
        }
    }
}