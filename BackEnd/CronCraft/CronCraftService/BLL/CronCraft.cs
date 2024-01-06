using CronCraftInterfaces;
using Microsoft.Extensions.Logging;
using ModelService.Hypercare;
using NLog.Extensions.Logging;

namespace CronCraftService.BLL
{
    public class CronCraft : ICronCraftService
    {
        private readonly ILogger _logger = (new NLogLoggerFactory()).CreateLogger<CronCraft>();

        public Task<bool> AddCronCraft(HyperCareScheduler taskSchedulerMap)
        {
            try
            {
                _logger.LogInformation("AddCronCraft called");
                return BusinessObjects.CronCraft.AddCronCraft(taskSchedulerMap);
            }
            catch (Exception ex)
            {
                _logger.LogError("AddCronCraft failed: {Error}", ex.Message);
                throw;
            }
        }

        public Task<IList<HyperCareScheduler>> GetCronCraft()
        {
            try
            {
                _logger.LogInformation("GetCronCraft called");
                return BusinessObjects.CronCraft.GetCronCraft();
            }
            catch (Exception ex)
            {
                _logger.LogError("GetCronCraft failed: {Error}", ex.Message);
                throw;
            }
        }

        public Task<IList<HyperCareScheduler>> GetCronCraftById(int scheduleId)
        {
            try
            {
                _logger.LogInformation("GetCronCraftById called");
                return BusinessObjects.CronCraft.GetCronCraftById(scheduleId);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetCronCraftById failed: {Error}", ex.Message);
                throw;
            }
        }

        public Task<bool> UpdateCronCraft(HyperCareScheduler taskSchedulerMap)
        {
            try
            {
                _logger.LogInformation("UpdateCronCraft called");
                return BusinessObjects.CronCraft.UpdateCronCraft(taskSchedulerMap);
            }
            catch (Exception ex)
            {
                _logger.LogError("UpdateCronCraft failed: {Error}", ex.Message);
                throw;
            }
        }

        public Task<bool> DeleteCronCraft(int scheduleId, string deletedBy)
        {
            try
            {
                _logger.LogInformation("DeleteCronCraft called");
                return BusinessObjects.CronCraft.DeleteCronCraft(scheduleId, deletedBy);
            }
            catch (Exception ex)
            {
                _logger.LogError("DeleteCronCraft failed: {Error}", ex.Message);
                throw;
            }
        }
    }
}
