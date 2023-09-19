import './App.css';
import React from 'react';
import Highcharts from 'highcharts';
import HighchartsReact from 'highcharts-react-official';
import { getUsageData } from './getUsageData';

const options = {
  chart: {
    type: 'spline'
  },
  title: {
    text: 'Energy Consumption'
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
