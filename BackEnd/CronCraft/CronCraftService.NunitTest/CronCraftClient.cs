using System.Net.Http.Json;

namespace CronCraftService.NunitTest
{
    public class CronCraftClient
    {
        private readonly string _apiBaseUrl;
        private static readonly ILogger<CronCraftClient> _logger = new NLogLoggerFactory().CreateLogger<CronCraftClient>();

        public CronCraftClient(string baseApiUrl)
        {
            _apiBaseUrl = baseApiUrl;
        }

        public async Task<IList<HyperCareScheduler>> GetCronCraft()
        {
            _logger.LogInformation("GetCronCraft called");
            string url = $"{_apiBaseUrl}/api/CronCraft/GetCronCraft";
            using HttpClient client = new();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<HyperCareScheduler>>(result);
            }
            else
            {
                _logger.LogError(response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<IList<HyperCareScheduler>> GetCronCraftById(int scheduleId)
        {
            _logger.LogInformation("GetCronCraftById called");
            string url = $"{_apiBaseUrl}/api/CronCraft/GetCronCraftById?scheduleId={scheduleId}";
            using HttpClient client = new();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<HyperCareScheduler>>(result);
            }
            else
            {
                _logger.LogError(response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<bool> AddCronCraft(HyperCareScheduler taskSchedulerMap)
        {
            _logger.LogInformation("AddCronCraft called");
            string url = $"{_apiBaseUrl}/api/CronCraft/AddCronCraft";
            using HttpClient client = new();
            var response = await client.PostAsJsonAsync(url, taskSchedulerMap);
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

        public async Task<bool> UpdateCronCraft(HyperCareScheduler taskSchedulerMap)
        {
            _logger.LogInformation("UpdateCronCraft called");
            string url = $"{_apiBaseUrl}/api/CronCraft/UpdateCronCraft";
            using HttpClient client = new();
            var response = await client.PutAsJsonAsync(url, taskSchedulerMap);
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
