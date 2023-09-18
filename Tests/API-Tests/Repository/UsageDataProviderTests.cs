using API;
using API.Models;
using API.Repository;
using Microsoft.Extensions.Configuration;
using NSubstitute;

namespace API_Tests;

public class UsageDataProviderTests
{
    private IFileParser<UsageData> _mockUsageParser;
    private IFileParser<Anomaly> _mockAnomalyParser;
    private IConfiguration _mockConfig;
    private IUsageDataProvider _usageDataProvider;

    [SetUp]
    public void Setup()
    {
        _mockUsageParser = Substitute.For<IFileParser<UsageData>>();
        _mockAnomalyParser = Substitute.For<IFileParser<Anomaly>>();
        _mockConfig = Substitute.For<IConfiguration>();
        _usageDataProvider = new UsageDataProvider(_mockConfig, _mockUsageParser, _mockAnomalyParser);
    }

    [Test]
    public void UsageDataProvider_WhenGivenCorrectInputData_ReturnsProcessedData()
    {
        var testUsageData = new List<UsageData>()
        {
            new UsageData()
            {
                Timestamp = DateTime.MinValue
            }
        };

        var testAnomalyData = new List<Anomaly>()
        {
            new Anomaly()
            {
                Timestamp = DateTime.MaxValue,
                Consumption = 1
            }
        };

        _mockUsageParser.ParseFile(Arg.Any<string>()).Returns(testUsageData);
        _mockAnomalyParser.ParseFile(Arg.Any<string>()).Returns(testAnomalyData);
        _mockConfig.GetValue<string>(Arg.Any<string>()).Returns("test-path");

        var expected = new List<ProcessedUsageData>()
        {
            new ProcessedUsageData()
            {
                Timestamp = DateTime.MinValue
            }
        };

        var result = _usageDataProvider.GetUsageData();

        Assert.That(result.ElementAt(0).Timestamp, Is.EqualTo(expected.ElementAt(0).Timestamp));
    }
}