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
            //TODO:parse anomalies here

            List<ProcessedUsageData> processedUsageData = new List<ProcessedUsageData>();

            foreach (var dataPoint in energyUsage)
            {
                var processedDataPoint = new ProcessedUsageData()
                {
                    Timestamp = dataPoint.Timestamp,
                    EnergyConsumption = dataPoint.EnergyConsumption,
                    AverageTemperature = dataPoint.AverageTemperature,
                    AverageHumidity = dataPoint.AverageHumidity
                };
                //TODO: check if present in anomalies and set bool

                processedUsageData.Add(processedDataPoint);
            }

            //IEnumerable<ProcessedUsageData> processedUsageData = new List<ProcessedUsageData>(){new ProcessedUsageData(){Timestamp = DateTime.Now, EnergyConsumption = 1.2}};

            return processedUsageData;
        }
    }
}