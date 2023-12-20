using ModelService.Hypercare;

namespace TeamProfilesInterfaces
{
    public interface ITeamProfileService
    {
        Task<bool> AddResponsibleTeam(HypercareResponsibleTeam responsibleTeam);
        Task<IList<HypercareResponsibleTeam>> GetModuleDataByResourceName(string resourceName);
        Task<IList<HypercareResponsibleTeam>> GetResourceByModueName(string moduleName);
        Task<IList<HypercareResponsibleTeam>> GetResponsibleTeam();
        Task<bool> UpdateResponsibleTeam(HypercareResponsibleTeam responsibleTeam);
    }
}
