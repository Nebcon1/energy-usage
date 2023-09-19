import './App.css';
import React from 'react';
import { render } from 'react-dom';
import Highcharts from 'highcharts';
import HighchartsReact from 'highcharts-react-official';

const getUsageData = async () => {
  try {
    const result = await fetch(`http://localhost:5035/EnergyData`);
    const usageData = await result.json();
    console.log(usageData);
  } catch (error) {
    console.log(error);
  }
};

const options = {
  chart: {
    type: 'spline'
  },
  title: {
    text: 'My chart'
  },
  series: [
    {
      data: [1, 2, 1, 4, 3, 6]
    }
  ]
};

function App() {
  return (
    <>
    <div>
      <HighchartsReact highcharts={Highcharts} options={options} />
    </div>
    <div className="App">
      <header className="App-header">
        <button onClick={getUsageData}>Make API call</button>
      </header>
    </div>
    </>
  );
}

export default App;
