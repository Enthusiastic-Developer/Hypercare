using ConfigurationService;
using Dapper;
using Microsoft.Extensions.Logging;
using ModelService.Hypercare;
using NLog.Extensions.Logging;
using System.Data;

namespace CareOpsManagerService.DAL
{
    public class CareOps
    {
        private readonly ILogger _logger = new NLogLoggerFactory().CreateLogger<CareOps>();
        public async Task<bool> AddCareOps(HyperCareTaskMaster careTaskMaster)
        {
            try
            {
                using IDbConnection con = ConnectionManager.GetLocalConnectionString();
                DynamicParameters parameters = new();
                parameters.Add("@TaskName", careTaskMaster.TaskName, DbType.String);
                parameters.Add("@TaskDesc", careTaskMaster.TaskDesc, DbType.String);
                parameters.Add("@ThresholdFromRange", careTaskMaster.ThresholdFromRange, DbType.Int32);
                parameters.Add("@ThresholdToRange", careTaskMaster.ThresholdToRange, DbType.Int32);
                parameters.Add("@Priority", careTaskMaster.Priority, DbType.String);
                parameters.Add("@Severity", careTaskMaster.Severity, DbType.String);
                parameters.Add("@ModuleName", careTaskMaster.ModuleName, DbType.String);
                parameters.Add("@Operations", careTaskMaster.Operations, DbType.String);
                parameters.Add("@Purpose", careTaskMaster.Purpose, DbType.String);
                parameters.Add("@WhatToMonitor", careTaskMaster.WhatToMonitor, DbType.String);
                parameters.Add("@DependsOn", careTaskMaster.DependsOn, DbType.String);
                parameters.Add("@IsActive", careTaskMaster.IsActive, DbType.Boolean);
                parameters.Add("@Threshold", careTaskMaster.Threshold, DbType.Int32);
                parameters.Add("@ResponsibleTeam", careTaskMaster.ResponsibleTeam, DbType.String);
                parameters.Add("@Operator", careTaskMaster.Operator, DbType.String);
                parameters.Add("@EmailTo", careTaskMaster.EmailTo, DbType.String);
                parameters.Add("@EmailCC", careTaskMaster.EmailCC, DbType.String);
                parameters.Add("@MonitoredBy", careTaskMaster.MonitoredBy, DbType.String);
                parameters.Add("@Method", careTaskMaster.Method, DbType.String);
                parameters.Add("@Frequency", careTaskMaster.Frequency, DbType.String);
                parameters.Add("@FrequencyCount1", careTaskMaster.FrequencyCount1, DbType.Int32);
                parameters.Add("@FrequencyCount2", careTaskMaster.FrequencyCount2, DbType.Int32);
                parameters.Add("@MinuteCount1", careTaskMaster.MinuteCount1, DbType.Int32);
                parameters.Add("@MinuteCount2", careTaskMaster.MinuteCount2, DbType.Int32);
                parameters.Add("@CreatedUser", careTaskMaster.CreatedUser, DbType.String);
                parameters.Add("@UpdatedUser", careTaskMaster.UpdatedUser, DbType.String);
                parameters.Add("@Success", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                await con.ExecuteAsync("HYPERCARE.[InsertHyperCareTaskMaster]", parameters, commandType: CommandType.StoredProcedure);
                bool success = parameters.Get<bool>("@Success");
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in AddCareOpsMethod {error}", ex.Message);
                throw;
            }
        }

        public Task<IList<HyperCareTaskMaster>> GetCareOps()
        {
            using IDbConnection con = ConnectionManager.GetLocalConnectionString();
            var sQuery = "SELECT * FROM HYPERCARE.HyperCareTaskMaster WITH(NOLOCK) ORDER BY 1 DESC";
            var result = con.Query<HyperCareTaskMaster>(sQuery).ToList();
            return Task.FromResult<IList<HyperCareTaskMaster>>(result);
        }

        public Task<IList<HyperCareTaskMaster>> GetCareOpsById(int taskId)
        {
            using IDbConnection con = ConnectionManager.GetLocalConnectionString();
            var sQuery = "SELECT * FROM HYPERCARE.HyperCareTaskMaster WITH(NOLOCK) WHERE HcTaskId = @TaskId ORDER BY 1 DESC";
            var result = con.Query<HyperCareTaskMaster>(sQuery, new { TaskId = taskId }).ToList();
            return Task.FromResult<IList<HyperCareTaskMaster>>(result);
        }

        public async Task<bool> UpdateCareOps(HyperCareTaskMaster careTaskMaster)
        {
            try
            {
                using IDbConnection con = ConnectionManager.GetLocalConnectionString();
                DynamicParameters parameters = new();
                parameters.Add("@HcTaskId", careTaskMaster.HcTaskId, DbType.Int32);
                parameters.Add("@TaskName", careTaskMaster.TaskName, DbType.String);
                parameters.Add("@TaskDesc", careTaskMaster.TaskDesc, DbType.String);
                parameters.Add("@ThresholdFromRange", careTaskMaster.ThresholdFromRange, DbType.Int32);
                parameters.Add("@ThresholdToRange", careTaskMaster.ThresholdToRange, DbType.Int32);
                parameters.Add("@Priority", careTaskMaster.Priority, DbType.String);
                parameters.Add("@Severity", careTaskMaster.Severity, DbType.String);
                parameters.Add("@ModuleName", careTaskMaster.ModuleName, DbType.String);
                parameters.Add("@Operations", careTaskMaster.Operations, DbType.String);
                parameters.Add("@Purpose", careTaskMaster.Purpose, DbType.String);
                parameters.Add("@WhatToMonitor", careTaskMaster.WhatToMonitor, DbType.String);
                parameters.Add("@DependsOn", careTaskMaster.DependsOn, DbType.String);
                parameters.Add("@IsActive", careTaskMaster.IsActive, DbType.Boolean);
                parameters.Add("@Threshold", careTaskMaster.Threshold, DbType.Int32);
                parameters.Add("@ResponsibleTeam", careTaskMaster.ResponsibleTeam, DbType.String);
                parameters.Add("@Operator", careTaskMaster.Operator, DbType.String);
                parameters.Add("@EmailTo", careTaskMaster.EmailTo, DbType.String);
                parameters.Add("@EmailCC", careTaskMaster.EmailCC, DbType.String);
                parameters.Add("@MonitoredBy", careTaskMaster.MonitoredBy, DbType.String);
                parameters.Add("@Method", careTaskMaster.Method, DbType.String);
                parameters.Add("@Frequency", careTaskMaster.Frequency, DbType.String);
                parameters.Add("@FrequencyCount1", careTaskMaster.FrequencyCount1, DbType.Int32);
                parameters.Add("@FrequencyCount2", careTaskMaster.FrequencyCount2, DbType.Int32);
                parameters.Add("@MinuteCount1", careTaskMaster.MinuteCount1, DbType.Int32);
                parameters.Add("@MinuteCount2", careTaskMaster.MinuteCount2, DbType.Int32);
                parameters.Add("@UpdatedUser", careTaskMaster.UpdatedUser, DbType.String);
                parameters.Add("@Success", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                await con.ExecuteAsync("HYPERCARE.[UpdateHyperCareTaskMaster]", parameters, commandType: CommandType.StoredProcedure);
                bool success = parameters.Get<bool>("@Success");
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in UpdateCareOpsMethod {error}", ex.Message);
                throw;
            }
        }

        public async Task<bool> DeleteCareOps(int taskId, string deletedBy)
        {
            try
            {
                using IDbConnection con = ConnectionManager.GetLocalConnectionString();
                DynamicParameters parameters = new();
                parameters.Add("@HcTaskId", taskId, DbType.Int32);
                parameters.Add("@DeletedBy", deletedBy, DbType.String);
                parameters.Add("@Success", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                await con.ExecuteAsync("[HYPERCARE].[DeleteAndArchiveHyperCareTaskMaster]", parameters, commandType: CommandType.StoredProcedure);
                bool success = parameters.Get<bool>("@Success");
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in DeleteCareOpsMethod {error}", ex.Message);
                throw;
            }
        }
    }
}
