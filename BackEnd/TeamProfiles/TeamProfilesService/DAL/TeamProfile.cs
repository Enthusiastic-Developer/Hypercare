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
                var sQuery = "SELECT Module,ResponsibleTeam,ActionType,NumberOfTasks,OnsiteTeam,PrimaryResource,SecondaryResource FROM HYPERCARE.HypercareResponsibleTeam WITH(NOLOCK)";
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
                var sQuery = "SELECT ResponsibleTeam,OnsiteTeam,PrimaryResource,SecondaryResource FROM HYPERCARE.HypercareResponsibleTeam WITH(NOLOCK) WHERE Module = @moduleName";
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
                var sQuery = "SELECT Module, ResponsibleTeam, ActionType, NumberOfTasks, OnsiteTeam, PrimaryResource, SecondaryResource FROM HYPERCARE.HypercareResponsibleTeam WITH (NOLOCK) WHERE OnsiteTeam = @ResourceName OR PrimaryResource = @ResourceName OR SecondaryResource = @ResourceName";
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
                var insertQuery = @"
                INSERT INTO HYPERCARE.HypercareResponsibleTeam
                (Module, ResponsibleTeam, ActionType, NumberOfTasks, OnsiteTeam, PrimaryResource, SecondaryResource,CreatedDate,CreatedUser,UpdatedDate,UpdatedUser)
                VALUES
                (@Module, @ResponsibleTeam, @ActionType, @NumberOfTasks, @OnsiteTeam, @PrimaryResource, @SecondaryResource,@CreatedDate,@CreatedUser,@UpdatedDate,@UpdatedUser)";

                var affectedRows = await con.ExecuteAsync(insertQuery, responsibleTeam);

                return affectedRows > 0;
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
                var updateQuery = @"
                UPDATE HYPERCARE.HypercareResponsibleTeam 
                SET ResponsibleTeam = @ResponsibleTeam, 
                    ActionType = @ActionType, 
                    NumberOfTasks = @NumberOfTasks, 
                    OnsiteTeam = @OnsiteTeam, 
                    PrimaryResource = @PrimaryResource, 
                    SecondaryResource = @SecondaryResource,
					Module = @Module,
					UpdatedDate = @UpdatedDate,
					UpdatedUser = @UpdatedUser
                WHERE SNo = @SNo";

                var affectedRows = await con.ExecuteAsync(updateQuery, responsibleTeam);

                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TeamProfile.UpdateResponsibleTeam at {Timestamp}: {Exception}", DateTime.Now, ex);
                throw;
            }
        }

    }
}
