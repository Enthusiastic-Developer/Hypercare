using ModelService.Hypercare;

namespace TeamProfilesInterfaces
{
    public interface ITeamProfileService
    {
        Task<bool> AddResponsibleTeam(HypercareResponsibleTeam responsibleTeam);
        Task<bool> DeleteResponsibleTeam(int teamId, string deletedBy);
        Task<IList<HypercareResponsibleTeam>> GetModuleDataByResourceName(string resourceName);
        Task<IList<HypercareResponsibleTeam>> GetResourceByModueName(string moduleName);
        Task<IList<HypercareResponsibleTeam>> GetResponsibleTeam();
        Task<bool> UpdateResponsibleTeam(HypercareResponsibleTeam responsibleTeam);
    }
}
