namespace CronCraftService.NunitTest
{
    public class CronCraftControllerTest
    {
        private const string _baseApiUrl = "http://localhost:5065";
        private CronCraftClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new CronCraftClient(_baseApiUrl);
        }

        [Test]
        public async Task GetCronCraft_ShouldReturnCronCraft()
        {
            List<string> passedTests = new();
            List<string> failedTests = new();

            var cronCraft = await _client.GetCronCraft();
            Assert.That(cronCraft, Is.Not.Null, "The returned list of cronCraft should not be null");
            Assert.That(cronCraft, Is.Not.Empty, "The returned list of cronCraft should have at least one cronCraft");

            foreach (var cron in cronCraft)
            {
                Assert.Multiple(() =>
                {
                    TrackAssertionResult(() =>
                    {
                        Assert.That(cron.HcSchId, Is.GreaterThanOrEqualTo(0), $"HcSchId should be greater than or equal to 0 for cronCraft {cron.HcSchId}");
                    }, "HcSchId", passedTests, failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(cron.SchedulerName, Is.Not.Null, $"SchedulerName should not be null for cronCraft {cron.SchedulerName}");
                    }, "SchedulerName", passedTests, failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(cron.SchedulerDesc, Is.Not.Null, $"SchedulerDesc should not be null for cronCraft {cron.SchedulerDesc}");
                    }, "SchedulerDesc", passedTests, failedTests);

                    DateTime expectedEndDate = DateTime.Parse("9999-12-31 00:00:00.000");
                    TrackAssertionResult(() =>
                    {
                        Assert.That(cron.EndDate, Is.EqualTo(expectedEndDate), $"EndDate should be {expectedEndDate} for cronCraft {cron.EndDate}");
                    }, "EndDate", passedTests, failedTests);

                    DateTime expectedScheduleTime = DateTime.Parse("1900-01-01 00:00:00.000");
                    TrackAssertionResult(() =>
                    {
                        Assert.That(cron.ScheduleTime, Is.EqualTo(expectedScheduleTime), $"ScheduleTime should be {expectedScheduleTime} for cronCraft {cron.ScheduleTime}");
                    }, "ScheduleTime", passedTests, failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(cron.IsActive, Is.TypeOf<bool>(), $"IsActive should be of type bool for cronCraft {cron.IsActive}");
                    }, "IsActive", passedTests, failedTests);
                });
            }

            // Display results
            TestContext.WriteLine("Test results:");
            TestContext.WriteLine($"Passed tests: {string.Join(", ", passedTests)}");
            TestContext.WriteLine($"Failed tests: {string.Join(", ", failedTests)}");
            Assert.That(failedTests, Is.Empty, "One or more tests failed.");
        }

        [Test]
        public async Task GetCronCraftById_ShouldReturnCronCraft()
        {
            List<string> passedTests = new();
            List<string> failedTests = new();

            var cronCraft = await _client.GetCronCraftById(1);
            Assert.That(cronCraft, Is.Not.Null, "The returned list of cronCraft should not be null");
            Assert.That(cronCraft, Is.Not.Empty, "The returned list of cronCraft should have at least one cronCraft");

            foreach (var cron in cronCraft)
            {
                Assert.Multiple(() =>
                {
                    TrackAssertionResult(() =>
                    {
                        Assert.That(cron.HcSchId, Is.GreaterThanOrEqualTo(0), $"HcSchId should be greater than or equal to 0 for cronCraft {cron.HcSchId}");
                    }, "HcSchId", passedTests, failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(cron.SchedulerName, Is.Not.Null, $"SchedulerName should not be null for cronCraft {cron.SchedulerName}");
                    }, "SchedulerName", passedTests, failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(cron.SchedulerDesc, Is.Not.Null, $"SchedulerDesc should not be null for cronCraft {cron.SchedulerDesc}");
                    }, "SchedulerDesc", passedTests, failedTests);

                    DateTime expectedEndDate = DateTime.Parse("9999-12-31 00:00:00.000");
                    TrackAssertionResult(() =>
                    {
                        Assert.That(cron.EndDate, Is.EqualTo(expectedEndDate), $"EndDate should be {expectedEndDate} for cronCraft {cron.EndDate}");
                    }, "EndDate", passedTests, failedTests);

                    DateTime expectedScheduleTime = DateTime.Parse("1900-01-01 00:00:00.000");
                    TrackAssertionResult(() =>
                    {
                        Assert.That(cron.ScheduleTime, Is.EqualTo(expectedScheduleTime), $"ScheduleTime should be {expectedScheduleTime} for cronCraft {cron.ScheduleTime}");
                    }, "ScheduleTime", passedTests, failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(cron.IsActive, Is.TypeOf<bool>(), $"IsActive should be of type bool for cronCraft {cron.IsActive}");
                    }, "IsActive", passedTests, failedTests);
                });
            }

            // Display results
            TestContext.WriteLine("Test results:");
            TestContext.WriteLine($"Passed tests: {string.Join(", ", passedTests)}");
            TestContext.WriteLine($"Failed tests: {string.Join(", ", failedTests)}");
            Assert.That(failedTests, Is.Empty, "One or more tests failed.");
        }

        [Test]
        public async Task AddCronCraft_ShouldReturnBool()
        {
            var schedule = new HyperCareScheduler
            {
                SchedulerName = "Test",
                SchedulerDesc = "Test",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.Parse("9999-12-31 00:00:00.000"),
                ScheduleTime = DateTime.Parse("1900-01-01 00:00:00.000"),
                CreatedDate = DateTime.UtcNow,
                CreatedUser = "UnitTest",
                UpdatedDate = DateTime.UtcNow,
                UpdatedUser = "UnitTest",
                IsActive = true,
                FrequencyStartDay = 0,
                FrequencyEndDay = 0,
                IsOneOff = false
            };
            var result = await _client.AddCronCraft(schedule);
            Assert.That(result, Is.True, "The returned result should be true");
        }

        [Test]
        public async Task UpdateCronCraft_ShouldReturnBool()
        {
            var schedule = new HyperCareScheduler
            {
                HcSchId = 22,
                SchedulerName = "Test-1",
                SchedulerDesc = "Test-1",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.Parse("9999-12-31 00:00:00.000"),
                ScheduleTime = DateTime.Parse("1900-01-01 00:00:00.000"),
                CreatedDate = DateTime.UtcNow,
                CreatedUser = "UnitTest",
                UpdatedDate = DateTime.UtcNow,
                UpdatedUser = "UnitTest",
                IsActive = true,
                FrequencyStartDay = 0,
                FrequencyEndDay = 0,
                IsOneOff = false
            };
            var result = await _client.UpdateCronCraft(schedule);
            Assert.That(result, Is.True, "The returned result should be true");
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
