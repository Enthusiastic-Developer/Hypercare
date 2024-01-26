using DashboardInterfaces;
using Microsoft.Extensions.Logging;
using ModelService.Dashboard;
using NLog.Extensions.Logging;

namespace DashboardService.BLL
{
    public class Dashboard : IDashboardService
    {
        private readonly ILogger _logger = new NLogLoggerFactory().CreateLogger<Dashboard>();

        public Task<IList<DailyCount>> GetCountForDay(DateTime fromDate, DateTime toDate)
        {
            try
            {
                _logger.LogInformation("GetCountForDay called");
                return BusinessObjects.Dashboard.GetCountForDay(fromDate, toDate);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetCountForDay failed: {Error}", ex.Message);
                throw;
            }
        }

        public Task<IList<DailyCount>> GetCountForTDay(DateTime dateTime)
        {
            try
            {
                _logger.LogInformation("GetCountForTDay called");
                return BusinessObjects.Dashboard.GetCountForTDay(dateTime);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetCountForTDay failed: {Error}", ex.Message);
                throw;
            }
        }

        public Task<IssueStatistics> GetIssueStatistics(DateTime fromDate, DateTime toDate)
        {
            try
            {
                _logger.LogInformation("GetIssueStatistics called");
                return BusinessObjects.Dashboard.GetIssueStatistics(fromDate, toDate);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetIssueStatistics failed: {Error}", ex.Message);
                throw;
            }
        }

        public Task<IssueStatistics> GetIssueStatisticsForTDay(DateTime dateTime)
        {
            try
            {
                _logger.LogInformation("GetIssueStatisticsForTDay called");
                return BusinessObjects.Dashboard.GetIssueStatisticsForTDay(dateTime);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetIssueStatisticsForTDay failed: {Error}", ex.Message);
                throw;
            }
        }

        public Task<IList<ModuleStatistics>> GetModuleStatistics(DateTime fromDate, DateTime toDate)
        {
            try
            {
                _logger.LogInformation("GetModuleStatistics called");
                return BusinessObjects.Dashboard.GetModuleStatistics(fromDate, toDate);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetModuleStatistics failed: {Error}", ex.Message);
                throw;
            }
        }

        public Task<IList<ModuleStatistics>> GetModuleStatisticsForTDay(DateTime dateTime)
        {
            try
            {
                _logger.LogInformation("GetModuleStatisticsForTDay called");
                return BusinessObjects.Dashboard.GetModuleStatisticsForTDay(dateTime);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetModuleStatisticsForTDay failed: {Error}", ex.Message);
                throw;
            }
        }
    }
}
