# energy-usage

Repo for a personal energy data analysis brief, looking at energy consumption/temperature data and associated anomalies.

## Building and Running

- The web layer utilises React and Javascript (requires Node.js), please install relevant dependencies based on your machine spec:

  - <https://nodejs.org/en/download>
  - <https://react.dev/>

- The API layer uses dotnet 7.0 webapis in C#, please install dotnet and associated C# extensions for your preferred development tool:

  - <https://dotnet.microsoft.com/en-us/download>
  - <https://code.visualstudio.com/docs/languages/csharp> (or relevant tool)

Documentation on building the application projects locally can be found on the above links, you will most likely use (npm start and dotnet run respectively).
**Always run the API before starting the Web component**

To run locally:

- Add your personal filepaths for the CSV files to the "appsettings.json" file:
  "CombinedUsageDataFilePath":"[YourPathHere]\\energy-usage\\Data\\CombinedDataSet.csv",
  "AnomalyDataFilePath":"[YourPathHere]\\energy-usage\\Data\\HalfHourlyEnergyDataAnomalies.csv"

- Ensure that the localhost URIs match when attempting to call the API from the Web:
  API:
  Update CORS in the "Program.cs" class if needed: policy.WithOrigins([your web localhost URI here]);
  Web:
  Update the API URI in "UsageGraph.js": const result = await fetch([your API localhost URI here]);
