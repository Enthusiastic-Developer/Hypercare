using ConfigurationService;
using Dapper;
using ModelService.Hypercare;
using System.Data;
using System.Text.Json;

namespace DataArchival.Services
{
    public class InsertJsonData
    {
        public void StartProcess()
        {
            string location = ConfigSettings.AppSettings["FileLocation"];

            // Read JSON files into objects
            List<HyperCareTaskMaster> taskMasterData = ReadJsonFile<HyperCareTaskMaster>(Path.Combine(location, "HyperCareTaskMaster.json"));
            List<HyperCareScheduler> schedulerData = ReadJsonFile<HyperCareScheduler>(Path.Combine(location, "HyperCareScheduler.json"));
            List<HypercareTaskSchedulerMap> taskSchedulerMapData = ReadJsonFile<HypercareTaskSchedulerMap>(Path.Combine(location, "HypercareTaskSchedulerMap.json"));
            List<HyperCareTracker> trackerData = ReadJsonFile<HyperCareTracker>(Path.Combine(location, "HyperCareTracker.json"));
            List<HyperCareTracker_History> trackerHistoryData = ReadJsonFile<HyperCareTracker_History>(Path.Combine(location, "HyperCareTracker_History.json"));

            using (var conn = ConnectionManager.GetLocalConnectionString())
            {
                conn.Open();

                // Insert data into SQL Server tables
                InsertDataIntoTable(conn, taskMasterData, "HyperCareTaskMaster");
                InsertDataIntoTable(conn, schedulerData, "HyperCareScheduler");
                InsertDataIntoTable(conn, taskSchedulerMapData, "HypercareTaskSchedulerMap");
                InsertDataIntoTable(conn, trackerData, "HyperCareTracker");
                InsertDataIntoTable(conn, trackerHistoryData, "HyperCareTracker_History");

                conn.Close();
            }

            Console.WriteLine("Data inserted into SQL Server tables.");
        }

        private static List<T> ReadJsonFile<T>(string filePath)
        {
            // Read JSON file into objects
            string jsonData = File.ReadAllText(filePath);
            List<T> data = JsonSerializer.Deserialize<List<T>>(jsonData);
            return data;
        }

        private void InsertDataIntoTable<T>(IDbConnection connection, List<T> data, string tableName)
        {
            // Insert data into SQL Server table
            string insertQuery = GetInsertQuery(tableName);
            connection.Execute(insertQuery, data);
        }

        private string GetInsertQuery(string tableName)
        {
            switch (tableName)
            {
                case "HyperCareTaskMaster":
                    return "INSERT INTO HyperCareTaskMaster(TaskName, TaskDesc, ThresholdFromRange, ThresholdToRange, CreatedDate, CreatedUser, UpdatedDate, UpdatedUser, Priority, Severity, ModuleName, Operations, Purpose, WhatToMonitor, DependsOn, IsActive, Threshold, ResponsibleTeam, Operator, EmailTo, EmailCC, MonitoredBy, Method, Frequency, FrequencyCount1, FrequencyCount2, MinuteCount1, MinuteCount2) VALUES (@TaskName, @TaskDesc, @ThresholdFromRange, @ThresholdToRange, @CreatedDate, @CreatedUser, @UpdatedDate, @UpdatedUser, @Priority, @Severity, @ModuleName, @Operations, @Purpose, @WhatToMonitor, @DependsOn, @IsActive, @Threshold, @ResponsibleTeam, @Operator, @EmailTo, @EmailCC, @MonitoredBy, @Method, @Frequency, @FrequencyCount1, @FrequencyCount2, @MinuteCount1, @MinuteCount2)";

                case "HyperCareScheduler":
                    return "INSERT INTO HyperCareScheduler(SchedulerName, SchedulerDesc, StartDate, EndDate, ScheduleTime, CreatedDate, CreatedUser, UpdatedDate, UpdatedUser, IsActive, Frequency, FrequencyStartDay, FrequencyEndDay, FrequencyStartDayName, IsOneOff) VALUES (@SchedulerName, @SchedulerDesc, @StartDate, @EndDate, @ScheduleTime, @CreatedDate, @CreatedUser, @UpdatedDate, @UpdatedUser, @IsActive, @Frequency, @FrequencyStartDay, @FrequencyEndDay, @FrequencyStartDayName, @IsOneOff)";

                case "HypercareTaskSchedulerMap":
                    return "INSERT INTO HypercareTaskSchedulerMap(HcTaskId, HcSchId, CreatedDate, CreatedUser, StartDate, EndDate, IsActive) VALUES (@HcTaskId, @HcSchId, @CreatedDate, @CreatedUser, @StartDate, @EndDate, @IsActive)";

                case "HyperCareTracker":
                    return "INSERT INTO HyperCareTracker(HcTaskId, HcSchId, ResponsibleTeam, ExecutionDate, ExecutionTime, RecordCount, Priority, CreatedDate, CreatedUser, IsEmailSent, IsIncidentCreated, IsThresholdCrossing) VALUES (@HcTaskId, @HcSchId, @ResponsibleTeam, @ExecutionDate, @ExecutionTime, @RecordCount, @Priority, @CreatedDate, @CreatedUser, @IsEmailSent, @IsIncidentCreated, @IsThresholdCrossing)";

                case "HyperCareTracker_History":
                    return "INSERT INTO HyperCareTracker_History(HcId, HcTaskId, HcSchId, ResponsibleTeam, ExecutionDate, ExecutionTime, RecordCount, Priority, CreatedDate, CreatedUser, HisDate, IsThresholdCrossing, IsEmailSent, IsIncidentCreated, RecordDescr) VALUES (@HcId, @HcTaskId, @HcSchId, @ResponsibleTeam, @ExecutionDate, @ExecutionTime, @RecordCount, @Priority, @CreatedDate, @CreatedUser, @HisDate, @IsThresholdCrossing, @IsEmailSent, @IsIncidentCreated, @RecordDescr)";

                default:
                    throw new ArgumentException($"Unsupported table name: {tableName}");
            }
        }
    }
}
