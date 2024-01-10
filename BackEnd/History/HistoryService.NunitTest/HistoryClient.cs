using ModelService.Common;

namespace HistoryService.NunitTest
{
    public class HistoryClient
    {
        private readonly string _apiBaseUrl;
        private static readonly ILogger<HistoryClient> _logger = new NLogLoggerFactory().CreateLogger<HistoryClient>();

        public HistoryClient(string baseApiUrl)
        {
            _apiBaseUrl = baseApiUrl;
        }

        public async Task<IList<HyperCareTracker>> GetHistory(Pagination pagination)
        {
            _logger.LogInformation("GetHistory called");
            string url = $"{_apiBaseUrl}/api/History/GetHistory";
            using HttpClient client = new();
            var response = await client.PostAsJsonAsync(url, pagination);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<HyperCareTracker>>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<IList<HyperCareTracker>> GetHistoryByTaskId(Pagination pagination, int taskId)
        {
            _logger.LogInformation("GetHistoryByTaskId called");
            string url = $"{_apiBaseUrl}/api/History/GetHistoryByTaskId?taskId={taskId}";
            using HttpClient client = new();
            var response = await client.PostAsJsonAsync(url, pagination);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<HyperCareTracker>>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<IList<HyperCareTracker>> GetHistoryByScheduleId(Pagination pagination, int scheduleId)
        {
            _logger.LogInformation("GetHistoryByScheduleId called");
            string url = $"{_apiBaseUrl}/api/History/GetHistoryByScheduleId?scheduleId={scheduleId}";
            using HttpClient client = new();
            var response = await client.PostAsJsonAsync(url, pagination);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<HyperCareTracker>>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<IList<HyperCareTracker>> GetHistoryBasedonDate(Pagination pagination, DateTime fromDate, DateTime toDate)
        {
            _logger.LogInformation("GetHistoryBasedonDate called");
            string url = $"{_apiBaseUrl}/api/History/GetHistoryBasedonDate?fromDate={fromDate}&toDate={toDate}";
            using HttpClient client = new();
            var response = await client.PostAsJsonAsync(url, pagination);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<HyperCareTracker>>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
