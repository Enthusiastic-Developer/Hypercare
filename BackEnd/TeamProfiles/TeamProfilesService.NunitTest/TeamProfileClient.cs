
namespace TeamProfilesService.NunitTest
{
    public class TeamProfileClient
    {
        private readonly string apiBaseUrl;
        private static readonly ILogger<TeamProfileClient> logger = new NLogLoggerFactory().CreateLogger<TeamProfileClient>();
        private readonly Microsoft.Extensions.Logging.ILogger _logger = logger;

        public TeamProfileClient(string baseApiUrl)
        {
            apiBaseUrl = baseApiUrl;
        }
        public async Task<IList<HypercareResponsibleTeam>> GetAllResponsibleTeam()
        {
            _logger.LogInformation("GetAllResponsibleTeam called");
            string url = $"{apiBaseUrl}/api/Team/GetAllResponsibleTeam";
            using HttpClient client = new();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<HypercareResponsibleTeam>>(result);
            }
            else
            {
                _logger.LogError(response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
