using API.Controllers;

namespace API.Models
{
    public class UsageData
    {
        public DateTime Timestamp { get; set; }
        public double EnergyConsumption {get; set;}
        public double AverageTemperature {get; set;}
        public float AverageHumidity {get; set;}
    }
}