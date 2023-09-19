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
        anomalyConsumption: [],
      };

      Object.entries(usageData).forEach(([key, val]) => {
        graphData.timestamp.push(val.timestamp);
        graphData.energyConsumption.push(val.energyConsumption);
        graphData.averageTemperature.push(val.averageTemperature);

        if (val.isAnomaly === true) {
          graphData.anomalyConsumption.push(val.energyConsumption);
        }
        //REVIEW: solution for anomaly mapping, likely more optimal ways to utilise highcharts
        else {
          graphData.anomalyConsumption.push(0);
        }
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
    yAxis: [
      {
        title: {
          text: "Energy Consumption",
          crosshair: true,
        },
      },
      {
        title: {
          text: "Temperature",
        },
        opposite: true,
      },
    ],
    tooltip: {
      shared: true,
      useHTML: true,
      headerFormat: '<table><tr><th colspan="2">{point.key}</th></tr>',
      pointFormat:
        '<tr><td style="color: {series.color}">{series.name} </td>' +
        '<td style="text-align: right"><b>{point.y}</b></td></tr>',
      footerFormat: "</table>",
      valueDecimals: 2,
    },
    annotations: [
      {
        draggable: false,
        labels: [
          {
            text: "A",
            customTooltipText: "Anomaly detected",
            point: {
              xAxis: data.anomalyTimestamps,
              yAxis: data.anomalyConsumption,
            },
          },
        ],
        labelOptions: {
          align: "right",
          backgroundColor: "rgb(224, 34, 0)",
          borderColor: "rgb(194, 29, 0)",
          style: {
            fontWeight: "bold",
          },
        },
      },
    ],
    series: [
      {
        name: "Energy Consumption",
        data: data.energyConsumption,
      },
      {
        name: "Temperature",
        data: data.averageTemperature,
        yAxis: 1,
      },
      {
        name: "Anomaly Detected at Consumption Value",
        data: data.anomalyConsumption,
        color: "#FF0000",
      },
    ],
  };

  return (
    <div>
      <HighchartsReact highcharts={Highcharts} options={options} />
    </div>
  );
}
