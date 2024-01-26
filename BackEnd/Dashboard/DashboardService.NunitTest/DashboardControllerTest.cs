namespace DashboardService.NunitTest
{
    public class DashboardControllerTest
    {
        private const string _baseApiUrl = "http://localhost:5074";
        private DashboardClient _client;
        readonly List<string> _passedTests = new();
        readonly List<string> _failedTests = new();

        [SetUp]
        public void Setup()
        {
            _client = new DashboardClient(_baseApiUrl);
        }

        [Test]
        public async Task GetCountForTDay_ShouldReturnCountForTDay()
        {
            DateTime dateTime = DateTime.Parse("2023-11-24");
            var countForTDay = await _client.GetCountForTDay(dateTime);
            Assert.That(countForTDay, Is.Not.Null, "The returned list of countForTDay should not be null");
            Assert.That(countForTDay, Is.Not.Empty, "The returned list of countForTDay should have at least one countForTDay");

            foreach (var count in countForTDay)
            {
                Assert.Multiple(() =>
                {
                    TrackAssertionResult(() =>
                    {
                        Assert.That(count.TotalCount, Is.GreaterThanOrEqualTo(0), $"Count should be greater than or equal to 0 for Dashboard {count.TotalCount}");
                    }, "TotalCount", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(count.Operations, Is.Not.Null, $"Operations should not be null for Dashboard {count.Operations}");
                    }, "Operations", _passedTests, _failedTests);
                });
            }
        }

        [Test]
        public async Task GetIssueStatisticsForTDay_ShouldReturnIssueStatisticsForTDay()
        {
            DateTime dateTime = DateTime.Parse("2023-11-24");
            var issueStatisticsForTDay = await _client.GetIssueStatisticsForTDay(dateTime);

            Assert.That(issueStatisticsForTDay, Is.Not.Null, "The returned object should not be null");

            TrackAssertionResult(() =>
            {
                Assert.That(issueStatisticsForTDay.TotalIssueCountOverall, Is.GreaterThanOrEqualTo(0), $"TotalIssueCountOverall should be greater than or equal to 0 for Dashboard {issueStatisticsForTDay.TotalIssueCountOverall}");
            }, "TotalIssueCountOverall", _passedTests, _failedTests);

            TrackAssertionResult(() =>
            {
                Assert.That(issueStatisticsForTDay.TotalIssueCountToday, Is.GreaterThanOrEqualTo(0), $"TotalIssueCountToday should be greater than or equal to 0 for Dashboard {issueStatisticsForTDay.TotalIssueCountToday}");
            }, "TotalIssueCountToday", _passedTests, _failedTests);

            TrackAssertionResult(() =>
            {
                Assert.That(issueStatisticsForTDay.BusinessCriticalCount, Is.GreaterThanOrEqualTo(0), $"BusinessCriticalCount should be greater than or equal to 0 for Dashboard {issueStatisticsForTDay.BusinessCriticalCount}");
            }, "BusinessCriticalCount", _passedTests, _failedTests);

            TrackAssertionResult(() =>
            {
                Assert.That(issueStatisticsForTDay.WarningCount, Is.GreaterThanOrEqualTo(0), $"WarningCount should be greater than or equal to 0 for Dashboard {issueStatisticsForTDay.WarningCount}");
            }, "WarningCount", _passedTests, _failedTests);
        }

        [Test]
        public async Task GetModuleStatisticsForTDay_ShouldReturnModuleStatisticsForTDay()
        {
            DateTime dateTime = DateTime.Parse("2023-11-24");
            var moduleStatisticsForTDay = await _client.GetModuleStatisticsForTDay(dateTime);

            Assert.That(moduleStatisticsForTDay, Is.Not.Null, "The returned list of moduleStatisticsForTDay should not be null");
            Assert.That(moduleStatisticsForTDay, Is.Not.Empty, "The returned list of moduleStatisticsForTDay should have at least one moduleStatisticsForTDay");

            foreach (var moduleStatistics in moduleStatisticsForTDay)
            {
                Assert.Multiple(() =>
                {
                    TrackAssertionResult(() =>
                    {
                        Assert.That(moduleStatistics.ModuleName, Is.Not.Null, $"ModuleName should not be null for Dashboard {moduleStatistics.ModuleName}");
                    }, "ModuleName", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(moduleStatistics.Operations, Is.Not.Null, $"Operations should not be null for Dashboard {moduleStatistics.Operations}");
                    }, "Operations", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(moduleStatistics.ResponsibleTeam, Is.Not.Null, $"ResponsibleTeam should not be null for Dashboard {moduleStatistics.ResponsibleTeam}");
                    }, "ResponsibleTeam", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(moduleStatistics.TotalCount, Is.GreaterThanOrEqualTo(0), $"TotalCount should be greater than or equal to 0 for Dashboard {moduleStatistics.TotalCount}");
                    }, "TotalCount", _passedTests, _failedTests);

                });
            }
        }

        [Test]
        public async Task GetCountForDay_ShouldReturnCountForDay()
        {
            DateTime fromDate = DateTime.Parse("2023-11-24");
            DateTime toDate = DateTime.Parse("2024-01-25");
            var countForDay = await _client.GetCountForDay(fromDate, toDate);

            Assert.That(countForDay, Is.Not.Null, "The returned list of countForTDay should not be null");
            Assert.That(countForDay, Is.Not.Empty, "The returned list of countForTDay should have at least one countForTDay");

            foreach (var count in countForDay)
            {
                Assert.Multiple(() =>
                {
                    TrackAssertionResult(() =>
                    {
                        Assert.That(count.TotalCount, Is.GreaterThanOrEqualTo(0), $"Count should be greater than or equal to 0 for Dashboard {count.TotalCount}");
                    }, "TotalCount", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(count.Operations, Is.Not.Null, $"Operations should not be null for Dashboard {count.Operations}");
                    }, "Operations", _passedTests, _failedTests);
                });
            }
        }

        [Test]
        public async Task GetIssueStatisticsForDay_ShouldReturnIssueStatisticsForDay()
        {
            DateTime fromDate = DateTime.Parse("2023-11-24");
            DateTime toDate = DateTime.Parse("2024-01-25");
            var issueStatisticsForDay = await _client.GetIssueStatistics(fromDate, toDate);

            Assert.That(issueStatisticsForDay, Is.Not.Null, "The returned object should not be null");

            TrackAssertionResult(() =>
            {
                Assert.That(issueStatisticsForDay.TotalIssueCountOverall, Is.GreaterThanOrEqualTo(0), $"TotalIssueCountOverall should be greater than or equal to 0 for Dashboard {issueStatisticsForDay.TotalIssueCountOverall}");
            }, "TotalIssueCountOverall", _passedTests, _failedTests);

            TrackAssertionResult(() =>
            {
                Assert.That(issueStatisticsForDay.TotalIssueCountToday, Is.GreaterThanOrEqualTo(0), $"TotalIssueCountToday should be greater than or equal to 0 for Dashboard {issueStatisticsForDay.TotalIssueCountToday}");
            }, "TotalIssueCountToday", _passedTests, _failedTests);

            TrackAssertionResult(() =>
            {
                Assert.That(issueStatisticsForDay.BusinessCriticalCount, Is.GreaterThanOrEqualTo(0), $"BusinessCriticalCount should be greater than or equal to 0 for Dashboard {issueStatisticsForDay.BusinessCriticalCount}");
            }, "BusinessCriticalCount", _passedTests, _failedTests);

            TrackAssertionResult(() =>
            {
                Assert.That(issueStatisticsForDay.WarningCount, Is.GreaterThanOrEqualTo(0), $"WarningCount should be greater than or equal to 0 for Dashboard {issueStatisticsForDay.WarningCount}");
            }, "WarningCount", _passedTests, _failedTests);
        }

        [Test]
        public async Task GetModuleStatisticsForDay_ShouldReturnModuleStatisticsForDay()
        {
            DateTime fromDate = DateTime.Parse("2023-11-24");
            DateTime toDate = DateTime.Parse("2024-01-25");
            var moduleStatisticsForDay = await _client.GetModuleStatistics(fromDate, toDate);

            Assert.That(moduleStatisticsForDay, Is.Not.Null, "The returned list of moduleStatisticsForDay should not be null");
            Assert.That(moduleStatisticsForDay, Is.Not.Empty, "The returned list of moduleStatisticsForDay should have at least one moduleStatisticsForDay");

            foreach (var moduleStatistics in moduleStatisticsForDay)
            {
                Assert.Multiple(() =>
                {
                    TrackAssertionResult(() =>
                    {
                        Assert.That(moduleStatistics.ModuleName, Is.Not.Null, $"ModuleName should not be null for Dashboard {moduleStatistics.ModuleName}");
                    }, "ModuleName", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(moduleStatistics.Operations, Is.Not.Null, $"Operations should not be null for Dashboard {moduleStatistics.Operations}");
                    }, "Operations", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(moduleStatistics.ResponsibleTeam, Is.Not.Null, $"ResponsibleTeam should not be null for Dashboard {moduleStatistics.ResponsibleTeam}");
                    }, "ResponsibleTeam", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(moduleStatistics.TotalCount, Is.GreaterThanOrEqualTo(0), $"TotalCount should be greater than or equal to 0 for Dashboard {moduleStatistics.TotalCount}");
                    }, "TotalCount", _passedTests, _failedTests);

                });
            }
        }


        private static void TrackAssertionResult(Action assertion, string testName, List<string> passedTests, List<string> failedTests)
        {
            try
            {
                assertion.Invoke();
                passedTests.Add(testName);
            }
            catch (Exception ex)
            {
                failedTests.Add(testName);
                TestContext.WriteLine($"Assertion failed for {testName}: {ex.Message}");
            }
        }
    }
}
