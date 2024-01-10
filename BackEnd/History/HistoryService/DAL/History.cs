using ConfigurationService;
using Dapper;
using Microsoft.Extensions.Logging;
using ModelService.Common;
using ModelService.Hypercare;
using NLog.Extensions.Logging;
using System.Data;

namespace HistoryService.DAL
{
    public class History
    {
        private readonly ILogger _logger = new NLogLoggerFactory().CreateLogger<History>();
        public Task<IList<HyperCareTracker>> GetHistory(Pagination pagination)
        {
            _logger.LogInformation("Entered GetHistory Method");
            using IDbConnection con = ConnectionManager.GetLocalConnectionString();
            DynamicParameters parameters = new();
            parameters.Add("@IN_PAGESIZE", pagination.PageSize, DbType.Int32);
            parameters.Add("@IN_PAGENUMBER", pagination.PageNumber, DbType.Int32);
            parameters.Add("@SortColumn", pagination.SortColumn, DbType.String);
            parameters.Add("@SortDir", pagination.SortDirection, DbType.Int32);

            var result = con.Query<HyperCareTracker>("[HYPERCARE].[GetHyperCareTrackerData]", parameters, commandType: CommandType.StoredProcedure).ToList();
            _logger.LogInformation("Exited GetHistory Method");
            return Task.FromResult<IList<HyperCareTracker>>(result);
        }

        public Task<IList<HyperCareTracker>> GetHistoryByTaskId(Pagination pagination, int taskId)
        {
            _logger.LogInformation("Entered GetHistoryByTaskId Method");
            using IDbConnection con = ConnectionManager.GetLocalConnectionString();
            DynamicParameters parameters = new();
            parameters.Add("@HcTaskId", taskId, DbType.Int32);
            parameters.Add("@IN_PAGENUMBER", pagination.PageNumber, DbType.Int32);
            parameters.Add("@IN_PAGESIZE", pagination.PageSize, DbType.Int32);
            parameters.Add("@SortColumn", pagination.SortColumn, DbType.String);
            parameters.Add("@SortDir", pagination.SortDirection, DbType.Int16);

            var result = con.Query<HyperCareTracker>("[HYPERCARE].[GetHyperCareTrackerDataByTaskId]", parameters, commandType: CommandType.StoredProcedure).ToList();
            _logger.LogInformation("Exited GetHistoryByTaskId Method");
            return Task.FromResult<IList<HyperCareTracker>>(result);
        }

        public Task<IList<HyperCareTracker>> GetHistoryBasedonDate(Pagination pagination, DateTime fromDate, DateTime toDate)
        {
            _logger.LogInformation("Entered GetHistoryBasedonDate Method");
            using IDbConnection con = ConnectionManager.GetLocalConnectionString();
            DynamicParameters parameters = new();
            parameters.Add("@FromDate", fromDate, DbType.DateTime);
            parameters.Add("@ToDate", toDate, DbType.DateTime);
            parameters.Add("@IN_PAGENUMBER", pagination.PageNumber, DbType.Int32);
            parameters.Add("@IN_PAGESIZE", pagination.PageSize, DbType.Int32);
            parameters.Add("@SortColumn", pagination.SortColumn, DbType.String);
            parameters.Add("@SortDir", pagination.SortDirection, DbType.Int16);

            var result = con.Query<HyperCareTracker>("[HYPERCARE].[GetHyperCareTrackerDataByDateRange]", parameters, commandType: CommandType.StoredProcedure).ToList();
            _logger.LogInformation("Exited GetHistoryByTaskId Method");
            return Task.FromResult<IList<HyperCareTracker>>(result);
        }

        public Task<IList<HyperCareTracker>> GetHistoryByScheduleId(Pagination pagination, int scheduleId)
        {
            _logger.LogInformation("Entered GetHistoryByTaskId Method");
            using IDbConnection con = ConnectionManager.GetLocalConnectionString();
            DynamicParameters parameters = new();
            parameters.Add("@HcSchId", scheduleId, DbType.Int32);
            parameters.Add("@IN_PAGENUMBER", pagination.PageNumber, DbType.Int32);
            parameters.Add("@IN_PAGESIZE", pagination.PageSize, DbType.Int32);
            parameters.Add("@SortColumn", pagination.SortColumn, DbType.String);
            parameters.Add("@SortDir", pagination.SortDirection, DbType.Int16);

            var result = con.Query<HyperCareTracker>("[HYPERCARE].[GetHyperCareTrackerDataBySchId]", parameters, commandType: CommandType.StoredProcedure).ToList();
            _logger.LogInformation("Exited GetHistoryByTaskId Method");
            return Task.FromResult<IList<HyperCareTracker>>(result);
        }
    }
}
