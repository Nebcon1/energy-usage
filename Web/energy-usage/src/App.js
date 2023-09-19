import './App.css';
import React from 'react';
import { Graph} from './getUsageData';
import {QueryClient, QueryClientProvider} from 'react-query';

const queryClient = new QueryClient();



function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <Graph></Graph>
    </QueryClientProvider>
  );
}

export default App;
