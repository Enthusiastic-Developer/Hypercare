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
        private readonly ILogger _logger = new NLogLoggerFactory().CreateLogger<MappingEngine>();
        public async Task<bool> AddMappingEngine(HypercareTaskSchedulerMap taskSchedulerMap)
        {
            try
            {
                using IDbConnection con = ConnectionManager.GetLocalConnectionString();

                DynamicParameters parameters = new();
                parameters.Add("@HcTaskId", taskSchedulerMap.HcTaskId, DbType.Int32);
                parameters.Add("@HcSchId", taskSchedulerMap.HcSchId, DbType.Int32);
                parameters.Add("@CreatedUser", taskSchedulerMap.CreatedUser, DbType.String);
                parameters.Add("@UpdatedUser", taskSchedulerMap.UpdatedUser, DbType.String);
                parameters.Add("@StartDate", taskSchedulerMap.StartDate, DbType.DateTime);
                parameters.Add("@EndDate", taskSchedulerMap.EndDate, DbType.DateTime);
                parameters.Add("@IsActive", taskSchedulerMap.IsActive, DbType.Boolean);
                parameters.Add("@Success", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                await con.ExecuteAsync("HYPERCARE.[InsertHypercareTaskSchedulerMap]", parameters, commandType: CommandType.StoredProcedure);
                bool success = parameters.Get<bool>("@Success");
                return success;
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

                DynamicParameters parameters = new();
                parameters.Add("@HcTsId", taskSchedulerMap.HcTsId, DbType.Int32);
                parameters.Add("@HcTaskId", taskSchedulerMap.HcTaskId, DbType.Int32);
                parameters.Add("@HcSchId", taskSchedulerMap.HcSchId, DbType.Int32);
                parameters.Add("@UpdatedUser", taskSchedulerMap.UpdatedUser, DbType.String);
                parameters.Add("@StartDate", taskSchedulerMap.StartDate, DbType.DateTime);
                parameters.Add("@EndDate", taskSchedulerMap.EndDate, DbType.DateTime);
                parameters.Add("@IsActive", taskSchedulerMap.IsActive, DbType.Boolean);
                parameters.Add("@Success", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                await con.ExecuteAsync("HYPERCARE.[UpdateHypercareTaskSchedulerMap]", parameters, commandType: CommandType.StoredProcedure);
                bool success = parameters.Get<bool>("@Success");
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in MappingEngine.UpdateMappingEngine at {Timestamp}: {Exception}", DateTime.Now, ex);
                throw;
            }
        }

        public async Task<bool> DeleteMappingEngine(int mappingId, string deletedBy)
        {
            try
            {
                using IDbConnection con = ConnectionManager.GetLocalConnectionString();
                DynamicParameters parameters = new();
                parameters.Add("@HcTsId", mappingId, DbType.Int32);
                parameters.Add("@DeletedBy", deletedBy, DbType.String);
                parameters.Add("@Success", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                await con.ExecuteAsync("[HYPERCARE].[DeleteAndArchiveHypercareTaskSchedulerMap]", parameters, commandType: CommandType.StoredProcedure);
                bool success = parameters.Get<bool>("@Success");
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in MappingEngine.UpdateMappingEngine at {Timestamp}: {Exception}", DateTime.Now, ex.Message);
                throw;
            }
        }
    }
}
