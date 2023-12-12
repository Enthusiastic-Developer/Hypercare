using ConfigurationService;
using Dapper;
using ModelService.Hypercare;
using System.Text.Json;

namespace DataArchival.Services
{
    public class JsonFileCreation
    {
        public void StartProcess()
        {
            List<HyperCareTracker> hyperCareTrackerData = new List<HyperCareTracker>();
            List<HypercareTaskSchedulerMap> hyperCareTaskSchedulerMapData = new List<HypercareTaskSchedulerMap>();
            List<HyperCareScheduler> hyperCareSchedulerData = new List<HyperCareScheduler>();
            List<HyperCareTaskMaster> hyperCareTaskMasterData = new List<HyperCareTaskMaster>();
            List<HyperCareTracker_History> hyperCareTrackerHistoryData = new List<HyperCareTracker_History>();

            using (var conn = ConnectionManager.GetInlineConnectionString())
            {
                string[] sQuery = new string[]
                {
                    "SELECT * FROM TOLLPLUS.HyperCareTaskMaster WITH(NOLOCK)",
                    "SELECT * FROM TOLLPLUS.HyperCareScheduler WITH(NOLOCK)",
                    "SELECT * FROM TOLLPLUS.HypercareTaskSchedulerMap WITH(NOLOCK)",
                    "SELECT * FROM TOLLPLUS.HyperCareTracker WITH(NOLOCK)",
                    "SELECT * FROM TOLLPLUS.HyperCareTracker_History WITH(NOLOCK)"
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
                        var data = conn.Query<HyperCareTracker_History>(query);
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

            // Create Json Files to a specific location
            string outputPath = @"\\192.168.50.130\M50Downloads\TempDocs";

            // Serialize and save each data set to a separate JSON file
            SaveToJsonFile(hyperCareTaskMasterData, Path.Combine(outputPath, "HyperCareTaskMaster.json"));
            SaveToJsonFile(hyperCareSchedulerData, Path.Combine(outputPath, "HyperCareScheduler.json"));
            SaveToJsonFile(hyperCareTaskSchedulerMapData, Path.Combine(outputPath, "HypercareTaskSchedulerMap.json"));
            SaveToJsonFile(hyperCareTrackerData, Path.Combine(outputPath, "HyperCareTracker.json"));
            SaveToJsonFile(hyperCareTrackerHistoryData, Path.Combine(outputPath, "HyperCareTracker_History.json"));

            Console.WriteLine("Json Files Created files");
        }

        private void SaveToJsonFile<T>(List<T> data, string filePath)
        {
            // Serialize the data to JSON
            string jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            // Write JSON data to the file
            File.WriteAllText(filePath, jsonData);
        }
    }
}
