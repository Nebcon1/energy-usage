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
    public void UsageDataProvider_GivenTimestampData_ReturnsMatchingProcessedData()
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

    [Test]
    public void UsageDataProvider_GivenFullUsageData_ReturnsMatchingProcessedData()
    {
        var testUsageData = new List<UsageData>()
        {
            new UsageData()
            {
                Timestamp = DateTime.MinValue,
                EnergyConsumption = 1.1,
                AverageTemperature = 2.2,
                AverageHumidity = 3.3
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
                Timestamp = DateTime.MinValue,
                EnergyConsumption = 1.1,
                AverageTemperature = 2.2,
                AverageHumidity = 3.3
            }
        };

        var result = _usageDataProvider.GetUsageData();

        Assert.That(result.ElementAt(0).Timestamp, Is.EqualTo(expected.ElementAt(0).Timestamp));
        Assert.That(result.ElementAt(0).EnergyConsumption, Is.EqualTo(expected.ElementAt(0).EnergyConsumption));
        Assert.That(result.ElementAt(0).AverageTemperature, Is.EqualTo(expected.ElementAt(0).AverageTemperature));
        Assert.That(result.ElementAt(0).AverageHumidity, Is.EqualTo(expected.ElementAt(0).AverageHumidity));
        Assert.That(result.ElementAt(0).IsAnomaly, Is.EqualTo(false));
    }

    [Test]
    public void UsageDataProvider_GivenAnomaly_SetsBoolInProcessedData()
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
                Timestamp = DateTime.MinValue
            }
        };

        _mockUsageParser.ParseFile(Arg.Any<string>()).Returns(testUsageData);
        _mockAnomalyParser.ParseFile(Arg.Any<string>()).Returns(testAnomalyData);
        _mockConfig.GetValue<string>(Arg.Any<string>()).Returns("test-path");

        var result = _usageDataProvider.GetUsageData();

        Assert.That(result.ElementAt(0).IsAnomaly, Is.EqualTo(true));
    }
}