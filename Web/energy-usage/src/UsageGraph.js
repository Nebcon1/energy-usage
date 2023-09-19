import { useQuery } from "react-query";
import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";

export function UsageGraph() {
  const getUsageData = async () => {
    try {
      const result = await fetch(`http://localhost:5035/EnergyData`);
      const usageData = await result.json();

      const graphData = {
        timestamp: [],
        energyConsumption: [],
        averageTemperature: [],
      };

      Object.entries(usageData).forEach(([key, val]) => {
        graphData.timestamp.push(val.timestamp);
        graphData.energyConsumption.push(val.energyConsumption);
        graphData.averageTemperature.push(val.averageTemperature);
      });

      return graphData;
    } catch (error) {
      console.log(error);
    }
  };

  const { data, error, isLoading } = useQuery("graphData", getUsageData);

  if (error) return <div>Request Failed</div>;
  if (isLoading) return <div>Loading...</div>;

  const options = {
    chart: {
      type: "spline",
    },
    title: {
      text: "A Graph Showing Lab Energy Consumption and Temperature",
    },
    xAxis: {
      title: {
        text: "Date and Time of Measurement",
      },
      categories: data.timestamp,
      crosshair: true,
    },
    yAxis:[{
      title:{
        text: "Energy Consumption",
        crosshair: true
      }      
    },
    {
      title:{
        text: "Temperature"
      },
      opposite: true   
    }],
    tooltip: {
      shared: true
  },
    series: [
      {
        name: "Energy Consumption",
        data: data.energyConsumption,
      },
      {
        name: "Temperature",
        data: data.averageTemperature,
        yAxis: 1
      },
    ],
  };

  return (
    <div>
      <HighchartsReact highcharts={Highcharts} options={options} />
    </div>
  );
}
