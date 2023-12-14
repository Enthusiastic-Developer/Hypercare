using ModelService.Hypercare;

namespace TeamProfilesInterfaces
{
    public interface ITeamProfileService
    {
        Task<IList<HypercareResponsibleTeam>> GetResponsibleTeam();
    }
}
