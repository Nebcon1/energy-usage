using System.Globalization;
using API.Models;
using CsvHelper;

namespace API.Repository
{
    public class AnomalyFileParser : IFileParser<Anomaly>
    {
        public IEnumerable<Anomaly> ParseFile(string filepath)
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
    }
}