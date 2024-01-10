using HistoryInterfaces;
using Microsoft.Extensions.Logging;
using ModelService.Common;
using ModelService.Hypercare;
using NLog.Extensions.Logging;

namespace HistoryService.BLL
{
    public class History : IHistoryService
    {
        private readonly ILogger _logger = new NLogLoggerFactory().CreateLogger<History>();
        public Task<IList<HyperCareTracker>> GetHistory(Pagination pagination)
        {
            try
            {
                _logger.LogInformation("GetHistory called");
                return BusinessObjects.History.GetHistory(pagination);
            }
            catch (Exception ex)
            {
                _logger.LogError("AddCareOpsManager failed: {Error}", ex.Message);
                throw;
            }
        }

        public Task<IList<HyperCareTracker>> GetHistoryBasedonDate(Pagination pagination, DateTime fromDate, DateTime toDate)
        {
            try
            {
                _logger.LogInformation("GetHistoryBasedonDate called");
                return BusinessObjects.History.GetHistoryBasedonDate(pagination, fromDate, toDate);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetHistoryBasedonDate failed: {Error}", ex.Message);
                throw;
            }
        }

        public Task<IList<HyperCareTracker>> GetHistoryByScheduleId(Pagination pagination, int scheduleId)
        {
            try
            {
                _logger.LogInformation("GetHistoryByScheduleId called");
                return BusinessObjects.History.GetHistoryByScheduleId(pagination, scheduleId);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetHistoryByScheduleId failed: {Error}", ex.Message);
                throw;
            }
        }

        public Task<IList<HyperCareTracker>> GetHistoryByTaskId(Pagination pagination, int taskId)
        {
            try
            {
                _logger.LogInformation("GetHistoryByTaskId called");
                return BusinessObjects.History.GetHistoryByTaskId(pagination, taskId);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetHistoryByTaskId failed: {Error}", ex.Message);
                throw;
            }
        }
    }
}
