import {useQuery} from 'react-query';
import Highcharts from 'highcharts';
import HighchartsReact from 'highcharts-react-official';

export function Graph()
{

const getUsageData = async () => {
  try {
    const result = await fetch(`http://localhost:5035/EnergyData`);
    const usageData = await result.json();

    const graphData = 
    {
      timestamp: [],
      energyConsumption: [],
      averageTemperature: []
    };

    Object.entries(usageData).forEach(([key, val]) => {
      graphData.timestamp.push(val.timestamp)
      graphData.energyConsumption.push(val.energyConsumption)
      graphData.averageTemperature.push(val.averageTemperature)
    })

    return graphData;
  }
  catch (error) 
  {
    console.log(error);
  }
};

const {data, error, isLoading} = useQuery('graphData', getUsageData);

if (error) return <div>Request Failed</div>;
if (isLoading) return <div>Loading...</div>;
const options = {
  chart: {
    type: 'spline'
  },
  title: {
    text: 'Energy Consumption'
  },
  xAxis: {
    categories: data.timestamp
  },//
  series: [
    {
      data: data.energyConsumption
    }
  ]
};

return(
  <div>
  <HighchartsReact highcharts={Highcharts} options={options} />
</div>
);

}