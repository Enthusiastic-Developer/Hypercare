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
                var sQuery = "INSERT INTO HYPERCARE.HyperCareScheduler(SchedulerName,SchedulerDesc,StartDate,EndDate,ScheduleTime,CreatedDate,CreatedUser,UpdatedDate,UpdatedUser,IsActive,Frequency,FrequencyStartDay,FrequencyEndDay,FrequencyStartDayName,IsOneOff) VALUES (@SchedulerName,@SchedulerDesc,@StartDate,@EndDate,@ScheduleTime,@CreatedDate,@CreatedUser,@UpdatedDate,@UpdatedUser,@IsActive,@Frequency,@FrequencyStartDay,@FrequencyEndDay,@FrequencyStartDayName,@IsOneOff)";
                var affectedRows = await con.ExecuteAsync(sQuery, taskSchedulerMap);
                return affectedRows > 0;
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
                var sQuery = "UPDATE HYPERCARE.HyperCareScheduler SET SchedulerName = @SchedulerName, SchedulerDesc = @SchedulerDesc, StartDate = @StartDate, EndDate = @EndDate, ScheduleTime = @ScheduleTime, CreatedDate = @CreatedDate, CreatedUser = @CreatedUser, UpdatedDate = @UpdatedDate, UpdatedUser = @UpdatedUser, IsActive = @IsActive, Frequency = @Frequency, FrequencyStartDay = @FrequencyStartDay, FrequencyEndDay = @FrequencyEndDay, FrequencyStartDayName = @FrequencyStartDayName, IsOneOff = @IsOneOff WHERE HcSchId = @HcSchId";
                var affectedRows = await con.ExecuteAsync(sQuery, taskSchedulerMap);
                return affectedRows > 0;
            }
            catch (Exception ex)
            {

                _logger.LogError("Error Occured in UpdateCronCraft {error}", ex.Message);
                throw; ;
            }
        }
    }
}
