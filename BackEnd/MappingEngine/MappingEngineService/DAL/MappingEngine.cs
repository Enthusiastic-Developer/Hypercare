using ConfigurationService;
using Dapper;
using Microsoft.Extensions.Logging;
using ModelService.Hypercare;
using NLog.Extensions.Logging;
using System.Data;

namespace MappingEngineService.DAL
{
    public class MappingEngine
    {
        private readonly ILogger _logger = (new NLogLoggerFactory()).CreateLogger<MappingEngine>();
        public async Task<bool> AddMappingEngine(HypercareTaskSchedulerMap taskSchedulerMap)
        {
            try
            {
                using IDbConnection con = ConnectionManager.GetLocalConnectionString();
                var insertQuery = @"INSERT INTO HYPERCARE.HypercareTaskSchedulerMap (HcTaskId,HcSchId,CreatedDate,CreatedUser,UpdatedDate,UpdatedUser,StartDate,EndDate,IsActive)  VALUES (@HcTaskId,@HcSchId,@CreatedDate,@CreatedUser,@UpdatedDate,@UpdatedUser,@StartDate,@EndDate,@IsActive)";
                var affectedRows = await con.ExecuteAsync(insertQuery, taskSchedulerMap);

                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in MappingEngine.AddMappingEngine at {Timestamp}: {Exception}", DateTime.Now, ex);
                throw;
            }
        }

        public Task<IList<HypercareTaskSchedulerMap>> GetMappingEngine()
        {
            using IDbConnection con = ConnectionManager.GetLocalConnectionString();
            var sQuery = "SELECT * FROM HYPERCARE.HypercareTaskSchedulerMap WITH(NOLOCK)";
            IList<HypercareTaskSchedulerMap> taskSchedulerMaps = con.Query<HypercareTaskSchedulerMap>(sQuery).ToList();
            return Task.FromResult(taskSchedulerMaps);
        }

        public Task<IList<HypercareTaskSchedulerMap>> GetMappingEngineByScheduleId(int scheduleId)
        {
            using IDbConnection con = ConnectionManager.GetLocalConnectionString();
            var sQuery = "SELECT * FROM HYPERCARE.HypercareTaskSchedulerMap WITH(NOLOCK) WHERE HcSchId = @scheduleId";
            IList<HypercareTaskSchedulerMap> taskSchedulerMaps = con.Query<HypercareTaskSchedulerMap>(sQuery, new { scheduleId }).ToList();
            return Task.FromResult(taskSchedulerMaps);
        }

        public Task<IList<HypercareTaskSchedulerMap>> GetMappingEngineByTaskId(int taskId)
        {
            using IDbConnection con = ConnectionManager.GetLocalConnectionString();
            var sQuery = "SELECT * FROM HYPERCARE.HypercareTaskSchedulerMap WITH(NOLOCK) WHERE HcTaskId = @taskId";
            IList<HypercareTaskSchedulerMap> taskSchedulerMaps = con.Query<HypercareTaskSchedulerMap>(sQuery, new { taskId }).ToList();
            return Task.FromResult(taskSchedulerMaps);
        }

        public async Task<bool> UpdateMappingEngine(HypercareTaskSchedulerMap taskSchedulerMap)
        {
            try
            {
                using IDbConnection con = ConnectionManager.GetLocalConnectionString();
                var updateQuery = @"UPDATE HYPERCARE.HypercareTaskSchedulerMap SET HcTaskId = @HcTaskId, HcSchId = @HcSchId, CreatedDate = @CreatedDate, CreatedUser = @CreatedUser, UpdatedDate = @UpdatedDate, UpdatedUser = @UpdatedUser, StartDate = @StartDate, EndDate = @EndDate, IsActive = @IsActive WHERE HcTsId = @HcTsId";
                var affectedRows = await con.ExecuteAsync(updateQuery, taskSchedulerMap);
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in MappingEngine.UpdateMappingEngine at {Timestamp}: {Exception}", DateTime.Now, ex);
                throw;
            }
        }
    }
}
