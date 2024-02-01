using ConfigurationService;
using Dapper;
using ModelService.Hypercare;
using System.Text.Json;

namespace DataArchival.Services
{
    public static class JsonFileCreation
    {
        public static void StartProcess()
        {
            string location = ConfigSettings.AppSettings["FileLocation"];
            List<HyperCareTracker> hyperCareTrackerData = new();
            List<HypercareTaskSchedulerMap> hyperCareTaskSchedulerMapData = new();
            List<HyperCareScheduler> hyperCareSchedulerData = new();
            List<HyperCareTaskMaster> hyperCareTaskMasterData = new();
            List<HyperCareTrackerHistory> hyperCareTrackerHistoryData = new();

            using (var conn = ConnectionManager.GetLocalConnectionString())
            {
                string[] sQuery = new string[]
                {
                    "SELECT * FROM HYPERCARE.HyperCareTaskMaster WITH(NOLOCK)",
                    "SELECT * FROM HYPERCARE.HyperCareScheduler WITH(NOLOCK)",
                    "SELECT * FROM HYPERCARE.HypercareTaskSchedulerMap WITH(NOLOCK)",
                    "SELECT * FROM HYPERCARE.HyperCareTracker WITH(NOLOCK)",
                    "SELECT * FROM HISTORY.HyperCareTracker_History WITH(NOLOCK)"
                };

                foreach (var query in sQuery)
                {
                    conn.Open();

                    if (query.Contains("HyperCareTaskMaster"))
                    {
                        var data = conn.Query<HyperCareTaskMaster>(query);
                        hyperCareTaskMasterData.AddRange(data);
                    }
                    else if (query.Contains("HyperCareScheduler"))
                    {
                        var data = conn.Query<HyperCareScheduler>(query);
                        hyperCareSchedulerData.AddRange(data);
                    }
                    else if (query.Contains("HypercareTaskSchedulerMap"))
                    {
                        var data = conn.Query<HypercareTaskSchedulerMap>(query);
                        hyperCareTaskSchedulerMapData.AddRange(data);
                    }
                    else if (query.Contains("HyperCareTracker_History"))
                    {
                        var data = conn.Query<HyperCareTrackerHistory>(query);
                        hyperCareTrackerHistoryData.AddRange(data);
                    }
                    else if (query.Contains("HyperCareTracker"))
                    {
                        var data = conn.Query<HyperCareTracker>(query);
                        hyperCareTrackerData.AddRange(data);
                    }

                    conn.Close();
                }
            }

            if (!Directory.Exists(location))
            {
                try
                {
                    Directory.CreateDirectory(location);
                    Console.WriteLine($"Directory '{location}' created successfully.");
                }
                catch (FileLoadException ex)
                {
                    Console.WriteLine("Error while creating directory: {0}", ex.Message);
                    throw;
                }
            }
            else
            {

                // Serialize and save each data set to a separate JSON file
                SaveToJsonFile(hyperCareTaskMasterData, Path.Combine(location, "HyperCareTaskMaster.json"));
                SaveToJsonFile(hyperCareSchedulerData, Path.Combine(location, "HyperCareScheduler.json"));
                SaveToJsonFile(hyperCareTaskSchedulerMapData, Path.Combine(location, "HypercareTaskSchedulerMap.json"));
                SaveToJsonFile(hyperCareTrackerData, Path.Combine(location, "HyperCareTracker.json"));
                SaveToJsonFile(hyperCareTrackerHistoryData, Path.Combine(location, "HyperCareTracker_History.json"));
            }
            Console.WriteLine("Json Files Created files");
        }

        private static void SaveToJsonFile<T>(List<T> data, string filePath)
        {
            // Serialize the data to JSON
            string jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            // Write JSON data to the file
            File.WriteAllText(filePath, jsonData);
        }
    }
}
