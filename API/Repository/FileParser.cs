using System.Globalization;
using API.Models;
using CsvHelper;

namespace API.Repository
{
    public class FileParser : IFileParser
    {
        public IEnumerable<Anomaly> ParseAnomalies(string filepath)
        {
            IEnumerable<Anomaly> anomalousData;

            using (var reader = new StreamReader(filepath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var data = csv.GetRecords<Anomaly>();
                anomalousData = data.ToList();
            }

            return anomalousData;
        }

        public IEnumerable<UsageData> ParseUsageData(string filepath)
        {
            IEnumerable<UsageData> usageData;

            using (var reader = new StreamReader(filepath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var data = csv.GetRecords<UsageData>();
                usageData = data.ToList();
            }

            return usageData;
        }
    }
}