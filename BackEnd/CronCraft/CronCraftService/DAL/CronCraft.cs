using ConfigurationService;
using Dapper;
using Microsoft.Extensions.Logging;
using ModelService.Hypercare;
using NLog.Extensions.Logging;
using System.Data;

namespace CronCraftService.DAL
{
    public class CronCraft
    {
        private readonly ILogger _logger = (new NLogLoggerFactory()).CreateLogger<CronCraft>();
        public async Task<bool> AddCronCraft(HyperCareScheduler taskSchedulerMap)
        {
            try
            {
                using IDbConnection con = ConnectionManager.GetLocalConnectionString();

                DynamicParameters parameters = new();
                parameters.Add("@SchedulerName", taskSchedulerMap.SchedulerName, DbType.String);
                parameters.Add("@SchedulerDesc", taskSchedulerMap.SchedulerDesc, DbType.String);
                parameters.Add("@StartDate", taskSchedulerMap.StartDate, DbType.DateTime);
                parameters.Add("@EndDate", taskSchedulerMap.EndDate, DbType.DateTime);
                parameters.Add("@ScheduleTime", taskSchedulerMap.ScheduleTime, DbType.DateTime);
                parameters.Add("@CreatedUser", taskSchedulerMap.CreatedUser, DbType.String);
                parameters.Add("@UpdatedUser", taskSchedulerMap.UpdatedUser, DbType.String);
                parameters.Add("@IsActive", taskSchedulerMap.IsActive, DbType.Boolean);
                parameters.Add("@Frequency", taskSchedulerMap.Frequency, DbType.String);
                parameters.Add("@FrequencyStartDay", taskSchedulerMap.FrequencyStartDay, DbType.Byte);
                parameters.Add("@FrequencyEndDay", taskSchedulerMap.FrequencyEndDay, DbType.Byte);
                parameters.Add("@FrequencyStartDayName", taskSchedulerMap.FrequencyStartDayName, DbType.String);
                parameters.Add("@IsOneOff", taskSchedulerMap.IsOneOff, DbType.Boolean);
                parameters.Add("@Success", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                await con.ExecuteAsync("HYPERCARE.[InsertHyperCareScheduler]", parameters, commandType: CommandType.StoredProcedure);
                bool success = parameters.Get<bool>("@Success");
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in AddCronCraft {error}", ex.Message);
                throw; ;
            }
        }

        public Task<IList<HyperCareScheduler>> GetCronCraft()
        {
            using IDbConnection con = ConnectionManager.GetLocalConnectionString();
            var sQuery = "SELECT * FROM HYPERCARE.HyperCareScheduler WITH(NOLOCK)";
            IList<HyperCareScheduler> schedulers = con.Query<HyperCareScheduler>(sQuery).ToList();
            return Task.FromResult(schedulers);
        }

        public Task<IList<HyperCareScheduler>> GetCronCraftById(int scheduleId)
        {
            using IDbConnection con = ConnectionManager.GetLocalConnectionString();
            var sQuery = "SELECT * FROM HYPERCARE.HyperCareScheduler WITH(NOLOCK) WHERE HcSchId = @scheduleId";
            IList<HyperCareScheduler> schedulers = con.Query<HyperCareScheduler>(sQuery, new { scheduleId }).ToList();
            return Task.FromResult(schedulers);
        }

        public async Task<bool> UpdateCronCraft(HyperCareScheduler taskSchedulerMap)
        {
            try
            {
                using IDbConnection con = ConnectionManager.GetLocalConnectionString();

                DynamicParameters parameters = new();
                parameters.Add("@HcSchId", taskSchedulerMap.HcSchId, DbType.Int32);
                parameters.Add("@SchedulerName", taskSchedulerMap.SchedulerName, DbType.String);
                parameters.Add("@SchedulerDesc", taskSchedulerMap.SchedulerDesc, DbType.String);
                parameters.Add("@StartDate", taskSchedulerMap.StartDate, DbType.DateTime);
                parameters.Add("@EndDate", taskSchedulerMap.EndDate, DbType.DateTime);
                parameters.Add("@ScheduleTime", taskSchedulerMap.ScheduleTime, DbType.DateTime);
                parameters.Add("@UpdatedUser", taskSchedulerMap.UpdatedUser, DbType.String);
                parameters.Add("@IsActive", taskSchedulerMap.IsActive, DbType.Boolean);
                parameters.Add("@Frequency", taskSchedulerMap.Frequency, DbType.String);
                parameters.Add("@FrequencyStartDay", taskSchedulerMap.FrequencyStartDay, DbType.Byte);
                parameters.Add("@FrequencyEndDay", taskSchedulerMap.FrequencyEndDay, DbType.Byte);
                parameters.Add("@FrequencyStartDayName", taskSchedulerMap.FrequencyStartDayName, DbType.String);
                parameters.Add("@IsOneOff", taskSchedulerMap.IsOneOff, DbType.Boolean);
                parameters.Add("@Success", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                await con.ExecuteAsync("HYPERCARE.[UpdateHyperCareScheduler]", parameters, commandType: CommandType.StoredProcedure);
                bool success = parameters.Get<bool>("@Success");
                return success;
            }
            catch (Exception ex)
            {

                _logger.LogError("Error Occured in UpdateCronCraft {error}", ex.Message);
                throw; ;
            }
        }
    }
}
