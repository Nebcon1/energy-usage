export const getUsageData = async () => {
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
