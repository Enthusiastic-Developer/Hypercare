using System.Net.Http.Json;

namespace CareOpsManagerService.NunitTest
{
    public class CareOpsManagerClient
    {
        private readonly string _apiBaseUrl;
        private static readonly ILogger<CareOpsManagerClient> _logger = new NLogLoggerFactory().CreateLogger<CareOpsManagerClient>();

        public CareOpsManagerClient(string baseApiUrl)
        {
            _apiBaseUrl = baseApiUrl;
        }

        public async Task<IList<HyperCareTaskMaster>> GetCareOpsManager()
        {
            _logger.LogInformation("GetCareOpsManager called");
            string url = $"{_apiBaseUrl}/api/CareOps/GetCareOps";
            using HttpClient client = new();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<HyperCareTaskMaster>>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<IList<HyperCareTaskMaster>> GetCareOpsManagerById(int taskId)
        {
            _logger.LogInformation("GetCareOpsManagerById called");
            string url = $"{_apiBaseUrl}/api/CareOps/GetCareOpsManagerById?taskId={taskId}";
            using HttpClient client = new();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<HyperCareTaskMaster>>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<bool> AddCareOpsManager(HyperCareTaskMaster careTaskMaster)
        {
            _logger.LogInformation("AddCareOpsManager called");
            string url = $"{_apiBaseUrl}/api/CareOps/AddCareOpsManager";
            using HttpClient client = new();
            var response = await client.PostAsJsonAsync(url, careTaskMaster);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<bool> UpdateCareOpsManager(HyperCareTaskMaster careTaskMaster)
        {
            _logger.LogInformation("UpdateCareOpsManager called");
            string url = $"{_apiBaseUrl}/api/CareOps/UpdateCareOpsManager";
            using HttpClient client = new();
            var response = await client.PutAsJsonAsync(url, careTaskMaster);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<bool> DeleteCareOpsManager(int taskId, string deletedBy)
        {
            _logger.LogInformation("DeleteCareOpsManager called");
            string url = $"{_apiBaseUrl}/api/CareOps/DeleteCareOpsManager?taskId={taskId}&deletedBy={deletedBy}";
            using HttpClient client = new();
            var response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
