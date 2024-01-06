using ModelService.Hypercare;

namespace TeamProfilesService.BusinessObjects
{
    public class TeamProfile
    {
        public static async Task<IList<HypercareResponsibleTeam>> GetResponsibleTeam()
        {
            return await Task.Run(() =>
            {
                return new DAL.TeamProfile().GetResponsibleTeam();
            });
        }

        public static async Task<IList<HypercareResponsibleTeam>> GetResourceByModueName(string moduleName)
        {
            return await Task.Run(() =>
            {
                return new DAL.TeamProfile().GetResourceByModueName(moduleName);
            });
        }

        public static async Task<IList<HypercareResponsibleTeam>> GetModuleDataByResourceName(string resourceName)
        {
            return await Task.Run(() =>
            {
                return new DAL.TeamProfile().GetModuleDataByResourceName(resourceName);
            });
        }

        public static async Task<bool> AddResponsibleTeam(HypercareResponsibleTeam responsibleTeam)
        {
            return await Task.Run(() =>
            {
                return new DAL.TeamProfile().AddResponsibleTeam(responsibleTeam);
            });
        }

        public static async Task<bool> UpdateResponsibleTeam(HypercareResponsibleTeam responsibleTeam)
        {
            return await Task.Run(() =>
            {
                return new DAL.TeamProfile().UpdateResponsibleTeam(responsibleTeam);
            });
        }

        public static Task<bool> DeleteResponsibleTeam(int teamId, string deletedBy)
        {
            return Task.Run(() =>
            {
                return new DAL.TeamProfile().DeleteResponsibleTeam(teamId, deletedBy);
            });
        }
    }
}
