import './App.css';
import React from 'react';
import { Graph, UsageGraph} from './UsageGraph';
import {QueryClient, QueryClientProvider} from 'react-query';

const queryClient = new QueryClient();



function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <UsageGraph></UsageGraph>
    </QueryClientProvider>
  );
}

export default App;
