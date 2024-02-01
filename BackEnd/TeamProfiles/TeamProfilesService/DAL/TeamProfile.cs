using ConfigurationService;
using Dapper;
using Microsoft.Extensions.Logging;
using ModelService.Hypercare;
using NLog.Extensions.Logging;
using System.Data;

namespace TeamProfilesService.DAL
{
    public class TeamProfile
    {
        private readonly ILogger _logger = new NLogLoggerFactory().CreateLogger<TeamProfile>();
        public Task<IList<HypercareResponsibleTeam>> GetResponsibleTeam()
        {
            try
            {
                using IDbConnection con = ConnectionManager.GetLocalConnectionString();
                var sQuery = "SELECT SNo, Module,ResponsibleTeam,ActionType,NumberOfTasks,OnsiteTeam,PrimaryResource,SecondaryResource FROM HYPERCARE.HypercareResponsibleTeam WITH(NOLOCK) ORDER BY 1 DESC";
                IList<HypercareResponsibleTeam> responsibleTeams = con.Query<HypercareResponsibleTeam>(sQuery).ToList();
                return Task.FromResult(responsibleTeams);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TeamProfile.GetResponsibleTeam at {Timestamp}: {Exception}", DateTime.Now, ex);
                throw;
            }
        }

        public Task<IList<HypercareResponsibleTeam>> GetResourceByModueName(string moduleName)
        {
            try
            {
                using IDbConnection con = ConnectionManager.GetLocalConnectionString();
                var sQuery = "SELECT ResponsibleTeam,OnsiteTeam,PrimaryResource,SecondaryResource FROM HYPERCARE.HypercareResponsibleTeam WITH(NOLOCK) WHERE Module = @moduleName ORDER BY 1 DESC";
                IList<HypercareResponsibleTeam> responsibleTeams = con.Query<HypercareResponsibleTeam>(sQuery, new { moduleName }).ToList();
                return Task.FromResult(responsibleTeams);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TeamProfile.GetResourceByModueName at {Timestamp}: {Exception}", DateTime.Now, ex);
                throw;
            }
        }

        public Task<IList<HypercareResponsibleTeam>> GetModuleDataByResourceName(string resourceName)
        {
            try
            {
                using IDbConnection con = ConnectionManager.GetLocalConnectionString();
                var sQuery = "SELECT Module, ResponsibleTeam, ActionType, NumberOfTasks, OnsiteTeam, PrimaryResource, SecondaryResource FROM HYPERCARE.HypercareResponsibleTeam WITH (NOLOCK) WHERE OnsiteTeam = @ResourceName OR PrimaryResource = @ResourceName OR SecondaryResource = @ResourceName ORDER BY 1 DESC";
                IList<HypercareResponsibleTeam> responsibleTeams = con.Query<HypercareResponsibleTeam>(sQuery, new { resourceName }).ToList();
                return Task.FromResult(responsibleTeams);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TeamProfile.GetModuleDataByResourceName at {Timestamp}: {Exception}", DateTime.Now, ex);
                throw;
            }
        }

        public async Task<bool> AddResponsibleTeam(HypercareResponsibleTeam responsibleTeam)
        {
            try
            {
                using IDbConnection con = ConnectionManager.GetLocalConnectionString();

                DynamicParameters parameters = new();
                parameters.Add("@Module", responsibleTeam.Module, DbType.String);
                parameters.Add("@ResponsibleTeam", responsibleTeam.ResponsibleTeam, DbType.String);
                parameters.Add("@ActionType", responsibleTeam.ActionType, DbType.String);
                parameters.Add("@NumberOfTasks", responsibleTeam.NumberOfTasks, DbType.Int32);
                parameters.Add("@OnsiteTeam", responsibleTeam.OnsiteTeam, DbType.String);
                parameters.Add("@PrimaryResource", responsibleTeam.PrimaryResource, DbType.String);
                parameters.Add("@SecondaryResource", responsibleTeam.SecondaryResource, DbType.String);
                parameters.Add("@CreatedUser", responsibleTeam.CreatedUser, DbType.String);
                parameters.Add("@UpdatedUser", responsibleTeam.UpdatedUser, DbType.String);
                parameters.Add("@Success", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                await con.ExecuteAsync("HYPERCARE.[InsertHypercareResponsibleTeam]", parameters, commandType: CommandType.StoredProcedure);
                bool success = parameters.Get<bool>("@Success");
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TeamProfile.AddResponsibleTeam at {Timestamp}: {Exception}", DateTime.Now, ex);
                throw;
            }
        }

        public async Task<bool> UpdateResponsibleTeam(HypercareResponsibleTeam responsibleTeam)
        {
            try
            {
                using IDbConnection con = ConnectionManager.GetLocalConnectionString();

                DynamicParameters parameters = new();
                parameters.Add("@SNo", responsibleTeam.SNo, DbType.Int32);
                parameters.Add("@Module", responsibleTeam.Module, DbType.String);
                parameters.Add("@ResponsibleTeam", responsibleTeam.ResponsibleTeam, DbType.String);
                parameters.Add("@ActionType", responsibleTeam.ActionType, DbType.String);
                parameters.Add("@NumberOfTasks", responsibleTeam.NumberOfTasks, DbType.Int32);
                parameters.Add("@OnsiteTeam", responsibleTeam.OnsiteTeam, DbType.String);
                parameters.Add("@PrimaryResource", responsibleTeam.PrimaryResource, DbType.String);
                parameters.Add("@SecondaryResource", responsibleTeam.SecondaryResource, DbType.String);
                parameters.Add("@UpdatedUser", responsibleTeam.UpdatedUser, DbType.String);
                parameters.Add("@Success", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                await con.ExecuteAsync("HYPERCARE.[UpdateHypercareResponsibleTeam]", parameters, commandType: CommandType.StoredProcedure);
                bool success = parameters.Get<bool>("@Success");
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TeamProfile.UpdateResponsibleTeam at {Timestamp}: {Exception}", DateTime.Now, ex);
                throw;
            }
        }

        public async Task<bool> DeleteResponsibleTeam(int teamId, string deletedBy)
        {
            try
            {
                using IDbConnection con = ConnectionManager.GetLocalConnectionString();
                DynamicParameters parameters = new();
                parameters.Add("@SNo", teamId, DbType.Int32);
                parameters.Add("@DeletedBy", deletedBy, DbType.String);
                parameters.Add("@Success", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                await con.ExecuteAsync("[HYPERCARE].[DeleteAndArchiveHypercareResponsibleTeam]", parameters, commandType: CommandType.StoredProcedure);
                bool success = parameters.Get<bool>("@Success");
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TeamProfile.DeleteResponsibleTeam at {Timestamp}: {Exception}", DateTime.Now, ex.Message);
                throw;
            }
        }
    }
}
