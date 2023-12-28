using ConfigurationService;
using Dapper;
using ModelService.Hypercare;
using System.Transactions;

namespace DataArchival.Services
{
    public class DataDump
    {
        public static void StartProcess()
        {
            List<HyperCareTracker> hyperCareTrackerData = new List<HyperCareTracker>();
            List<HypercareTaskSchedulerMap> hyperCareTaskSchedulerMapData = new List<HypercareTaskSchedulerMap>();
            List<HyperCareScheduler> hyperCareSchedulerData = new List<HyperCareScheduler>();
            List<HyperCareTaskMaster> hyperCareTaskMasterData = new List<HyperCareTaskMaster>();
            List<HyperCareTracker_History> hyperCareTrackerHistoryData = new List<HyperCareTracker_History>();
            TransactionOptions transactionOptions = new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted, Timeout = TimeSpan.FromSeconds(Convert.ToInt32(ConfigSettings.AppSettings["CommandTimeout"].ToString())) };

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

            //Insert into the new database
            using (var connS = ConnectionManager.GetLocalConnectionString())
            {
                string[] insertQuery = new string[]
                {
                    "INSERT INTO HYPERCARE.HyperCareTaskMaster(TaskName,TaskDesc,ThresholdFromRange,ThresholdToRange,CreatedDate,CreatedUser,UpdatedDate,UpdatedUser,Priority,Severity,ModuleName,Operations,Purpose,WhatToMonitor,DependsOn,IsActive,Threshold,ResponsibleTeam,Operator,EmailTo,EmailCC,MonitoredBy,Method,Frequency,FrequencyCount1,FrequencyCount2,MinuteCount1,MinuteCount2) VALUES (@TaskName,@TaskDesc,@ThresholdFromRange,@ThresholdToRange,@CreatedDate,@CreatedUser,@UpdatedDate,@UpdatedUser,@Priority,@Severity,@ModuleName,@Operations,@Purpose,@WhatToMonitor,@DependsOn,@IsActive,@Threshold,@ResponsibleTeam,@Operator,@EmailTo,@EmailCC,@MonitoredBy,@Method,@Frequency,@FrequencyCount1,@FrequencyCount2,@MinuteCount1,@MinuteCount2)",
                    "INSERT INTO HYPERCARE.HyperCareScheduler(SchedulerName,SchedulerDesc,StartDate,EndDate,ScheduleTime,CreatedDate,CreatedUser,UpdatedDate,UpdatedUser,IsActive,Frequency,FrequencyStartDay,FrequencyEndDay,FrequencyStartDayName,IsOneOff) VALUES (@SchedulerName,@SchedulerDesc,@StartDate,@EndDate,@ScheduleTime,@CreatedDate,@CreatedUser,@UpdatedDate,@UpdatedUser,@IsActive,@Frequency,@FrequencyStartDay,@FrequencyEndDay,@FrequencyStartDayName,@IsOneOff)",
                    "INSERT INTO HYPERCARE.HypercareTaskSchedulerMap(HcTaskId,HcSchId,CreatedDate,CreatedUser,UpdatedDate,UpdatedUser,StartDate,EndDate,IsActive) VALUES (@HcTaskId,@HcSchId,@CreatedDate,@CreatedUser,@UpdatedDate,@UpdatedUser,@StartDate,@EndDate,@IsActive)",
                    "INSERT INTO HYPERCARE.HypercareTracker(HcTaskId,HcSchId,ResponsibleTeam,ExecutionDate,ExecutionTime,RecordCount,Priority,CreatedDate,CreatedUser,IsEmailSent,IsIncidentCreated,IsThresholdCrossing,RecordDescr) VALUES (@HcTaskId,@HcSchId,@ResponsibleTeam,@ExecutionDate,@ExecutionTime,@RecordCount,@Priority,@CreatedDate,@CreatedUser,@IsEmailSent,@IsIncidentCreated,@IsThresholdCrossing,@RecordDescr)",
                    "INSERT INTO HISTORY.HyperCareTracker_History(HcId,HcTaskId,HcSchId,ResponsibleTeam,ExecutionDate,ExecutionTime,RecordCount,Priority,CreatedDate,CreatedUser,HisDate,IsThresholdCrossing,IsEmailSent,IsIncidentCreated,RecordDescr) VALUES (@HcId,@HcTaskId,@HcSchId,@ResponsibleTeam,@ExecutionDate,@ExecutionTime,@RecordCount,@Priority,@CreatedDate,@CreatedUser,@HisDate,@IsThresholdCrossing,@IsEmailSent,@IsIncidentCreated,@RecordDescr)"
                };
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
                {
                    foreach (var query in insertQuery)
                    {
                        connS.Open();

                        if (query.Contains("HyperCareTaskMaster"))
                        {
                            connS.Execute(query, hyperCareTaskMasterData);
                        }
                        else if (query.Contains("HyperCareScheduler"))
                        {
                            connS.Execute(query, hyperCareSchedulerData);
                        }
                        else if (query.Contains("HypercareTaskSchedulerMap"))
                        {
                            hyperCareTaskSchedulerMapData.ForEach(x =>
                            {
                                x.UpdatedDate = x.CreatedDate;
                                x.UpdatedUser = x.CreatedUser;
                            });
                            connS.Execute(query, hyperCareTaskSchedulerMapData);
                        }
                        else if (query.Contains("HyperCareTracker_History"))
                        {
                            connS.Execute(query, hyperCareTrackerHistoryData);
                        }
                        else if (query.Contains("HyperCareTracker"))
                        {
                            connS.Execute(query, hyperCareTrackerData);
                        }

                        connS.Close();
                    }
                    scope.Complete();
                }
            }
        }
    }
}
