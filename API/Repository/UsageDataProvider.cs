using System.Drawing;
using API.Models;
using API.Repository;

namespace API
{
    public class UsageDataProvider : IUsageDataProvider
    {
        private IConfiguration _config;
        private readonly IFileParser<UsageData> _usageFileParser;
        private readonly IFileParser<Anomaly> _anomalyFileParser;

        public UsageDataProvider(IConfiguration config, IFileParser<UsageData> usageFileParser, IFileParser<Anomaly> anomalyFileParser)
        {
            _config = config;
            _usageFileParser = usageFileParser;
            _anomalyFileParser = anomalyFileParser;
        }

        public IEnumerable<ProcessedUsageData> GetUsageData()
        {
            IEnumerable<UsageData> energyUsage = _usageFileParser.ParseFile(_config.GetValue<string>("CombinedUsageDataFilePath") ?? "Set filepath in app settings.");
            var t = _config.GetValue<string>("AnomalyDataFilePath") ?? "Set filepath in app settings.";
            IEnumerable<Anomaly> anomalies = _anomalyFileParser.ParseFile(_config.GetValue<string>("AnomalyDataFilePath") ?? "Set filepath in app settings.");

            List<ProcessedUsageData> processedUsageData = new List<ProcessedUsageData>();
            IEnumerable<DateTime> dateTimes = from anomaly in anomalies select anomaly.Timestamp;

            foreach (var dataPoint in energyUsage)
            {
                var processedDataPoint = new ProcessedUsageData()
                {
                    Timestamp = new DateTime(dataPoint.Timestamp.Ticks),
                    EnergyConsumption = dataPoint.EnergyConsumption,
                    AverageTemperature = dataPoint.AverageTemperature,
                    AverageHumidity = dataPoint.AverageHumidity,
                    IsAnomaly = false
                };

                if (dateTimes.Contains(processedDataPoint.Timestamp))
                {
                    processedDataPoint.IsAnomaly = true;
                };

                processedUsageData.Add(processedDataPoint);
            }

            return processedUsageData;
        }
    }
}