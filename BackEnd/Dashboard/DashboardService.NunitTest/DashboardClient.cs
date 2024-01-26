using ModelService.Dashboard;

namespace DashboardService.NunitTest
{
    public class DashboardClient
    {
        private readonly string _apiBaseUrl;
        private static readonly ILogger<DashboardClient> _logger = new NLogLoggerFactory().CreateLogger<DashboardClient>();

        public DashboardClient(string baseApiUrl)
        {
            _apiBaseUrl = baseApiUrl;
        }

        public async Task<IList<DailyCount>> GetCountForTDay(DateTime dateTime)
        {
            string formattedDateTime = dateTime.ToString("yyyy-MM-dd");
            _logger.LogInformation("GetCountForTDay called");
            string url = $"{_apiBaseUrl}/api/Dashboard/GetCountForTDay?dateTime={formattedDateTime}";
            using HttpClient client = new();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<DailyCount>>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<IssueStatistics> GetIssueStatisticsForTDay(DateTime dateTime)
        {
            string formattedDateTime = dateTime.ToString("yyyy-MM-dd");
            _logger.LogInformation("GetIssueStatisticsForTDay called");
            string url = $"{_apiBaseUrl}/api/Dashboard/GetIssueStatisticsForTDay?dateTime={formattedDateTime}";
            using HttpClient client = new();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IssueStatistics>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<IList<ModuleStatistics>> GetModuleStatisticsForTDay(DateTime dateTime)
        {
            string formattedDateTime = dateTime.ToString("yyyy-MM-dd");
            _logger.LogInformation("GetModuleStatisticsForTDay called");
            string url = $"{_apiBaseUrl}/api/Dashboard/GetModuleStatisticsForTDay?dateTime={formattedDateTime}";
            using HttpClient client = new();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<ModuleStatistics>>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<IList<DailyCount>> GetCountForDay(DateTime fromDate, DateTime toDate)
        {
            string formattedFromDateTime = fromDate.ToString("yyyy-MM-dd");
            string formattedToDateTime = toDate.ToString("yyyy-MM-dd");
            _logger.LogInformation("GetCountForDay called");
            string url = $"{_apiBaseUrl}/api/Dashboard/GetCountForDay?fromDate={formattedFromDateTime}&toDate={formattedToDateTime}";
            using HttpClient client = new();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<DailyCount>>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<IssueStatistics> GetIssueStatistics(DateTime fromDate, DateTime toDate)
        {
            string formattedFromDateTime = fromDate.ToString("yyyy-MM-dd");
            string formattedToDateTime = toDate.ToString("yyyy-MM-dd");
            _logger.LogInformation("GetIssueStatistics called");
            string url = $"{_apiBaseUrl}/api/Dashboard/GetIssueStatistics?fromDate={formattedFromDateTime}&toDate={formattedToDateTime}";
            using HttpClient client = new();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IssueStatistics>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<IList<ModuleStatistics>> GetModuleStatistics(DateTime fromDate, DateTime toDate)
        {
            string formattedFromDateTime = fromDate.ToString("yyyy-MM-dd");
            string formattedToDateTime = toDate.ToString("yyyy-MM-dd");
            _logger.LogInformation("GetModuleStatistics called");
            string url = $"{_apiBaseUrl}/api/Dashboard/GetModuleStatistics?fromDate={formattedFromDateTime}&toDate={formattedToDateTime}";
            using HttpClient client = new();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<ModuleStatistics>>(result);
            }
            else
            {
                _logger.LogError("Error occurred: {ReasonPhrase}", response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
