using ConfigurationService;
using Dapper;
using Microsoft.Extensions.Logging;
using ModelService.Dashboard;
using NLog.Extensions.Logging;
using System.Data;

namespace DashboardService.DAL
{
    public class Dashboard
    {
        private readonly ILogger _logger = new NLogLoggerFactory().CreateLogger<Dashboard>();

        public async Task<IList<DailyCount>> GetCountForDay(DateTime fromDate, DateTime toDate)
        {
            using IDbConnection con = ConnectionManager.GetLocalConnectionString();
            DynamicParameters parameters = new();
            parameters.Add("@fromDate", fromDate, DbType.DateTime);
            parameters.Add("@toDate", toDate, DbType.DateTime);

            IEnumerable<DailyCount> counts = await con.QueryAsync<DailyCount>("[HYPERCARE].[GetHyperCareOperationsCountForDays]", parameters, commandType: CommandType.StoredProcedure);
            IList<DailyCount> countList = counts.ToList();
            return countList;
        }

        public async Task<IList<DailyCount>> GetCountForTDay(DateTime dateTime)
        {
            using IDbConnection con = ConnectionManager.GetLocalConnectionString();
            DynamicParameters parameters = new();
            parameters.Add("@TargetDate", dateTime, DbType.DateTime);
            IEnumerable<DailyCount> counts = await con.QueryAsync<DailyCount>("[HYPERCARE].[GetHyperCareOperationsCountForDay]", parameters, commandType: CommandType.StoredProcedure);
            IList<DailyCount> countList = counts.ToList();
            return countList;
        }

        public async Task<IssueStatistics> GetIssueStatistics(DateTime fromDate, DateTime toDate)
        {
            using IDbConnection con = ConnectionManager.GetLocalConnectionString();
            DynamicParameters parameters = new();
            parameters.Add("@fromDate", fromDate, DbType.DateTime);
            parameters.Add("@toDate", toDate, DbType.DateTime);
            IssueStatistics iStatistics = await con.QueryFirstOrDefaultAsync<IssueStatistics>("[HYPERCARE].[GetHyperCareIssueStatisticsForDays]", parameters, commandType: CommandType.StoredProcedure);
            return iStatistics;
        }

        public async Task<IssueStatistics> GetIssueStatisticsForTDay(DateTime dateTime)
        {
            using IDbConnection con = ConnectionManager.GetLocalConnectionString();
            DynamicParameters parameters = new();
            parameters.Add("@TargetDate", dateTime, DbType.DateTime);
            IssueStatistics iStatistics = await con.QueryFirstOrDefaultAsync<IssueStatistics>("[HYPERCARE].[GetHyperCareIssueStatisticsForDay]", parameters, commandType: CommandType.StoredProcedure);
            return iStatistics;
        }

        public async Task<IList<ModuleStatistics>> GetModuleStatistics(DateTime fromDate, DateTime toDate)
        {
            using IDbConnection con = ConnectionManager.GetLocalConnectionString();
            DynamicParameters parameters = new();
            parameters.Add("@fromDate", fromDate, DbType.DateTime);
            parameters.Add("@toDate", toDate, DbType.DateTime);
            IEnumerable<ModuleStatistics> mStatistics = await con.QueryAsync<ModuleStatistics>("[HYPERCARE].[GetHyperCareModuleStatisticsForDays]", parameters, commandType: CommandType.StoredProcedure);
            IList<ModuleStatistics> mStatisticsList = mStatistics.ToList();
            return mStatisticsList;
        }

        public async Task<IList<ModuleStatistics>> GetModuleStatisticsForTDay(DateTime dateTime)
        {
            using IDbConnection con = ConnectionManager.GetLocalConnectionString();
            DynamicParameters parameters = new();
            parameters.Add("@TargetDate", dateTime, DbType.DateTime);
            IEnumerable<ModuleStatistics> mStatistics = await con.QueryAsync<ModuleStatistics>("[HYPERCARE].[GetHyperCareModuleStatisticsForDay]", parameters, commandType: CommandType.StoredProcedure);
            IList<ModuleStatistics> mStatisticsList = mStatistics.ToList();
            return mStatisticsList;
        }
    }
}
