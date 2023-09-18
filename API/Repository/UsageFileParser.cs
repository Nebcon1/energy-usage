using System.Globalization;
using API.Models;
using CsvHelper;

namespace API.Repository
{
    public class UsageFileParser : IFileParser<UsageData>
    {
        public IEnumerable<UsageData> ParseFile(string filepath)
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