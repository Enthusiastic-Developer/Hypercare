using ModelService.Hypercare;

namespace TeamProfilesService.BusinessObjects
{
    public class TeamProfile
    {
        readonly DAL.TeamProfile _teamProfile = new DAL.TeamProfile();
        public async Task<IList<HypercareResponsibleTeam>> GetResponsibleTeam()
        {
            return await Task.Run(() =>
            {
                return new DAL.TeamProfile().GetResponsibleTeam();
            });
        }
    }
}
