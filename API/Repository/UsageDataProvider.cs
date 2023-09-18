using System.Drawing;
using API.Models;
using API.Repository;

namespace API
{
    public class UsageDataProvider : IUsageDataProvider
    {
        private readonly IFileParser _fileParser;

        public UsageDataProvider(IFileParser fileParser)
        {
            _fileParser = fileParser;
        }

        public IEnumerable<ProcessedUsageData> GetUsageData()
        {
            IEnumerable<UsageData> energyUsage = _fileParser.ParseUsageData("C:\\Users\\ben.connolly\\OneDrive - Accenture\\Documents\\IW-BC\\Personal\\EnergyUsage\\energy-usage\\Data\\CombinedDataSet.csv");
            IEnumerable<Anomaly> anomalies = _fileParser.ParseAnomalies("C:\\Users\\ben.connolly\\OneDrive - Accenture\\Documents\\IW-BC\\Personal\\EnergyUsage\\energy-usage\\Data\\HalfHourlyEnergyDataAnomalies.csv");

            List<ProcessedUsageData> processedUsageData = new List<ProcessedUsageData>();
            IEnumerable<DateTime> dateTimes = from anomaly in anomalies select anomaly.Timestamp;

            foreach (var dataPoint in energyUsage)
            {
                var processedDataPoint = new ProcessedUsageData()
                {
                    Timestamp = dataPoint.Timestamp,
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