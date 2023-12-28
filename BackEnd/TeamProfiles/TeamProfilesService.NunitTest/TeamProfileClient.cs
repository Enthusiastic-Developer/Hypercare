
using System.Net.Http.Json;

namespace TeamProfilesService.NunitTest
{
    public class TeamProfileClient
    {
        private readonly string _apiBaseUrl;
        private static readonly ILogger<TeamProfileClient> _logger = new NLogLoggerFactory().CreateLogger<TeamProfileClient>();

        public TeamProfileClient(string baseApiUrl)
        {
            _apiBaseUrl = baseApiUrl;
        }
        public async Task<IList<HypercareResponsibleTeam>> GetAllResponsibleTeam()
        {
            _logger.LogInformation("GetAllResponsibleTeam called");
            string url = $"{_apiBaseUrl}/api/Team/GetAllResponsibleTeam";
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

        public async Task<IList<HypercareResponsibleTeam>> GetResourceByModuleName(string moduleName)
        {
            _logger.LogInformation("GetResourceByModuleName called");

            // Construct the URL with the moduleName parameter
            string url = $"{_apiBaseUrl}/api/Team/GetResourceByModueName?moduleName={moduleName}";

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

        public async Task<IList<HypercareResponsibleTeam>> GetModuleDataByResourceName(string resourceName)
        {
            _logger.LogInformation("GetModuleDataByResourceName called");
            string url = $"{_apiBaseUrl}/api/Team/GetModuleDataByResourceName?resourceName={resourceName}";
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

        public async Task<bool> AddResponsibleTeam(HypercareResponsibleTeam responsibleTeam)
        {
            _logger.LogInformation("AddResponsibleTeam called");
            string url = $"{_apiBaseUrl}/api/Team/AddResponsibleTeam";
            using HttpClient client = new();
            var response = await client.PostAsJsonAsync(url, responsibleTeam);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(result);
            }
            else
            {
                _logger.LogError(response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<bool> UpdateResponsibleTeam(HypercareResponsibleTeam responsibleTeam)
        {
            _logger.LogInformation("UpdateResponsibleTeam called");
            string url = $"{_apiBaseUrl}/api/Team/UpdateResponsibleTeam";
            using HttpClient client = new();
            var response = await client.PutAsJsonAsync(url, responsibleTeam);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(result);
            }
            else
            {
                _logger.LogError(response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
