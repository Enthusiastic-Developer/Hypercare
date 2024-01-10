using ModelService.Common;

namespace HistoryService.NunitTest
{
    public class HistoryControllerTest
    {
        private const string _baseApiUrl = "http://localhost:5219";
        private HistoryClient _client;
        readonly List<string> _passedTests = new();
        readonly List<string> _failedTests = new();

        [SetUp]
        public void Setup()
        {
            _client = new HistoryClient(_baseApiUrl);
        }

        [Test]
        public async Task GetAllHistory_ShouldreturnHistory()
        {
            Pagination pagination = new()
            {
                PageNumber = 1,
                PageSize = 10,
                SortDirection = 1,
                SortColumn = "IsThresholdCrossing"
            };
            var historys = await _client.GetHistory(pagination);
            Assert.That(historys, Is.Not.Null, "The returned list of history should not be null");
            Assert.That(historys, Is.Not.Empty, "The returned list of history should have at least one record");
            foreach (var history in historys)
            {
                Assert.Multiple(() =>
                {
                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.HcSchId, Is.GreaterThanOrEqualTo(0), $"HcSchId should be greater than or equal to 0 for history {history.HcSchId}");
                    }, "HcSchId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.HcTaskId, Is.GreaterThanOrEqualTo(0), $"HcTaskId should be greater than or equal to 0 for history {history.HcTaskId}");
                    }, "HcTaskId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.HcId, Is.GreaterThanOrEqualTo(0), $"HcId should be greater than or equal to 0 for history {history.HcId}");
                    }, "HcId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.HcId, Is.GreaterThanOrEqualTo(0), $"HcId should be greater than or equal to 0 for history {history.HcId}");
                    }, "HcId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.RecordCount, Is.GreaterThanOrEqualTo(0), $"RecordCount should be greater than or equal to 0 for history {history.RecordCount}");
                    }, "RecordCount", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.ResponsibleTeam, Is.Not.Null.Or.Empty, "ResponsibleTeam should not be null or empty");
                    }, "ResponsibleTeam", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.Priority, Is.Not.Null.Or.Empty, "Priority should not be null or empty");
                    }, "Priority", _passedTests, _failedTests);
                });
            }
        }

        [Test]
        public async Task GetHistoryByTaskId_ShouldreturnHistory()
        {
            Pagination pagination = new()
            {
                PageNumber = 1,
                PageSize = 10,
                SortDirection = 1,
                SortColumn = "IsThresholdCrossing"
            };
            var historys = await _client.GetHistoryByTaskId(pagination, 62);
            Assert.That(historys, Is.Not.Null, "The returned list of history should not be null");
            Assert.That(historys, Is.Not.Empty, "The returned list of history should have at least one record");
            foreach (var history in historys)
            {
                Assert.Multiple(() =>
                {
                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.HcSchId, Is.GreaterThanOrEqualTo(0), $"HcSchId should be greater than or equal to 0 for history {history.HcSchId}");
                    }, "HcSchId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.HcTaskId, Is.GreaterThanOrEqualTo(0), $"HcTaskId should be greater than or equal to 0 for history {history.HcTaskId}");
                    }, "HcTaskId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.HcId, Is.GreaterThanOrEqualTo(0), $"HcId should be greater than or equal to 0 for history {history.HcId}");
                    }, "HcId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.HcId, Is.GreaterThanOrEqualTo(0), $"HcId should be greater than or equal to 0 for history {history.HcId}");
                    }, "HcId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.RecordCount, Is.GreaterThanOrEqualTo(0), $"RecordCount should be greater than or equal to 0 for history {history.RecordCount}");
                    }, "RecordCount", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.ResponsibleTeam, Is.Not.Null.Or.Empty, "ResponsibleTeam should not be null or empty");
                    }, "ResponsibleTeam", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.Priority, Is.Not.Null.Or.Empty, "Priority should not be null or empty");
                    }, "Priority", _passedTests, _failedTests);
                });
            }
        }

        [Test]
        public async Task GetHistoryByScheduleId_ShouldreturnHistory()
        {
            Pagination pagination = new()
            {
                PageNumber = 1,
                PageSize = 10,
                SortDirection = 1,
                SortColumn = "IsThresholdCrossing"
            };
            var historys = await _client.GetHistoryByScheduleId(pagination, 13);
            Assert.That(historys, Is.Not.Null, "The returned list of history should not be null");
            Assert.That(historys, Is.Not.Empty, "The returned list of history should have at least one record");
            foreach (var history in historys)
            {
                Assert.Multiple(() =>
                {
                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.HcSchId, Is.GreaterThanOrEqualTo(0), $"HcSchId should be greater than or equal to 0 for history {history.HcSchId}");
                    }, "HcSchId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.HcTaskId, Is.GreaterThanOrEqualTo(0), $"HcTaskId should be greater than or equal to 0 for history {history.HcTaskId}");
                    }, "HcTaskId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.HcId, Is.GreaterThanOrEqualTo(0), $"HcId should be greater than or equal to 0 for history {history.HcId}");
                    }, "HcId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.HcId, Is.GreaterThanOrEqualTo(0), $"HcId should be greater than or equal to 0 for history {history.HcId}");
                    }, "HcId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.RecordCount, Is.GreaterThanOrEqualTo(0), $"RecordCount should be greater than or equal to 0 for history {history.RecordCount}");
                    }, "RecordCount", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.ResponsibleTeam, Is.Not.Null.Or.Empty, "ResponsibleTeam should not be null or empty");
                    }, "ResponsibleTeam", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.Priority, Is.Not.Null.Or.Empty, "Priority should not be null or empty");
                    }, "Priority", _passedTests, _failedTests);
                });
            }
        }

        [Test]
        public async Task GetHistoryBasedonDate_ShouldreturnHistory()
        {
            Pagination pagination = new()
            {
                PageNumber = 1,
                PageSize = 10,
                SortDirection = 1,
                SortColumn = "IsThresholdCrossing"
            };
            DateTime startDate = DateTime.Parse("2024-01-01");
            DateTime endDate = DateTime.Parse("2024-01-07");
            var historys = await _client.GetHistoryBasedonDate(pagination, startDate, endDate);
            Assert.That(historys, Is.Not.Null, "The returned list of history should not be null");
            Assert.That(historys, Is.Not.Empty, "The returned list of history should have at least one record");
            foreach (var history in historys)
            {
                Assert.Multiple(() =>
                {
                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.HcSchId, Is.GreaterThanOrEqualTo(0), $"HcSchId should be greater than or equal to 0 for history {history.HcSchId}");
                    }, "HcSchId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.HcTaskId, Is.GreaterThanOrEqualTo(0), $"HcTaskId should be greater than or equal to 0 for history {history.HcTaskId}");
                    }, "HcTaskId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.HcId, Is.GreaterThanOrEqualTo(0), $"HcId should be greater than or equal to 0 for history {history.HcId}");
                    }, "HcId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.HcId, Is.GreaterThanOrEqualTo(0), $"HcId should be greater than or equal to 0 for history {history.HcId}");
                    }, "HcId", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.RecordCount, Is.GreaterThanOrEqualTo(0), $"RecordCount should be greater than or equal to 0 for history {history.RecordCount}");
                    }, "RecordCount", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.ResponsibleTeam, Is.Not.Null.Or.Empty, "ResponsibleTeam should not be null or empty");
                    }, "ResponsibleTeam", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(history.Priority, Is.Not.Null.Or.Empty, "Priority should not be null or empty");
                    }, "Priority", _passedTests, _failedTests);
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
