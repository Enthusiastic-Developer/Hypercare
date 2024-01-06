namespace TeamProfilesService.NunitTest
{
    [TestFixture]
    public class TeamControllerTest
    {
        private const string _baseApiUrl = "http://localhost:5139";
        private TeamProfileClient _client;
        readonly List<string> _passedTests = new();
        readonly List<string> _failedTests = new();

        [SetUp]
        public void Setup()
        {
            _client = new TeamProfileClient(_baseApiUrl);
        }

        [Test]
        public async Task GetAllResponsibleTeam_ShouldReturnTeams()
        {
            var teams = await _client.GetAllResponsibleTeam();
            Assert.That(teams, Is.Not.Null, "The returned list of teams should not be null");
            Assert.That(teams, Is.Not.Empty, "The returned list of teams should have at least one team");
            foreach (var team in teams)
            {
                Assert.Multiple(() =>
                {
                    TrackAssertionResult(() =>
                    {
                        Assert.That(team.SNo, Is.GreaterThanOrEqualTo(0), $"SNo should be greater than or equal to 0 for team {team.ResponsibleTeam}");
                    }, "SNo", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(team.Module, Is.Not.Null.Or.Empty, "Module should not be null or empty");
                    }, "Module", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(team.ResponsibleTeam, Is.Not.Null.Or.Empty, "ResponsibleTeam should not be null or empty");
                    }, "ResponsibleTeam", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(team.ActionType, Is.Not.Null.Or.Empty, "ActionType should not be null or empty");
                    }, "ActionType", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(team.NumberOfTasks, Is.GreaterThanOrEqualTo(0), $"NumberOfTasks should be greater than or equal to 0 for team {team.ResponsibleTeam}");
                    }, "NumberOfTasks", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(team.OnsiteTeam, Is.Not.Null.Or.Empty.Or.EqualTo(team.PrimaryResource).Or.Null.Or.EqualTo(team.SecondaryResource).Or.Null, $"At least one of OnsiteTeam, PrimaryResource, or SecondaryResource should be present for team {team.ResponsibleTeam}");
                    }, "OnsiteTeam, PrimaryResource, or SecondaryResource", _passedTests, _failedTests);
                });
            }
            TestContext.WriteLine("Test results:");
            TestContext.WriteLine($"Passed tests: {string.Join(", ", _passedTests)}");
            TestContext.WriteLine($"Failed tests: {string.Join(", ", _failedTests)}");
            Assert.That(_failedTests, Is.Empty, "One or more tests failed.");
        }

        [Test]
        public async Task GetResourceByModuleName_ShouldReturnTeams()
        {
            var teams = await _client.GetResourceByModuleName("Account Mgmt");
            Assert.That(teams, Is.Not.Null, "The returned list of teams should not be null");
            Assert.That(teams, Is.Not.Empty, "The returned list of teams should have at least one team");
            foreach (var team in teams)
            {
                Assert.Multiple(() =>
                {
                    TrackAssertionResult(() =>
                    {
                        Assert.That(team.NumberOfTasks, Is.GreaterThanOrEqualTo(0), $"NumberOfTasks should be greater than or equal to 0 for team {team.ResponsibleTeam}");
                    }, "NumberOfTasks", _passedTests, _failedTests);

                    TrackAssertionResult(() =>
                    {
                        Assert.That(team.OnsiteTeam, Is.Not.Null.Or.Empty.Or.EqualTo(team.PrimaryResource).Or.Null.Or.EqualTo(team.SecondaryResource).Or.Null, $"At least one of OnsiteTeam, PrimaryResource, or SecondaryResource should be present for team {team.ResponsibleTeam}");
                    }, "OnsiteTeam, PrimaryResource, or SecondaryResource", _passedTests, _failedTests);

                });
            }
            TestContext.WriteLine("Test results:");
            TestContext.WriteLine($"Passed tests: {string.Join(", ", _passedTests)}");
            TestContext.WriteLine($"Failed tests: {string.Join(", ", _failedTests)}");
            Assert.That(_failedTests, Is.Empty, "One or more tests failed.");
        }

        [Test]
        public async Task GetModuleDataByResourceName_ShouldReturnTeams()
        {
            var teams = await _client.GetModuleDataByResourceName("THALA");
            Assert.That(teams, Is.Not.Null, "The returned list of teams should not be null");
            Assert.That(teams, Is.Not.Empty, "The returned list of teams should have at least one team");
            foreach (var team in teams)
            {
                Assert.Multiple(() =>
                {
                    Assert.Multiple(() =>
                    {
                        TrackAssertionResult(() =>
                        {
                            Assert.That(team.SNo, Is.GreaterThanOrEqualTo(0), $"SNo should be greater than or equal to 0 for team {team.ResponsibleTeam}");
                        }, "SNo", _passedTests, _failedTests);

                        TrackAssertionResult(() =>
                        {
                            Assert.That(team.Module, Is.Not.Null.Or.Empty, "Module should not be null or empty");
                        }, "Module", _passedTests, _failedTests);

                        TrackAssertionResult(() =>
                        {
                            Assert.That(team.ResponsibleTeam, Is.Not.Null.Or.Empty, "ResponsibleTeam should not be null or empty");
                        }, "ResponsibleTeam", _passedTests, _failedTests);

                        TrackAssertionResult(() =>
                        {
                            Assert.That(team.ActionType, Is.Not.Null.Or.Empty, "ActionType should not be null or empty");
                        }, "ActionType", _passedTests, _failedTests);

                        TrackAssertionResult(() =>
                        {
                            Assert.That(team.NumberOfTasks, Is.GreaterThanOrEqualTo(0), $"NumberOfTasks should be greater than or equal to 0 for team {team.ResponsibleTeam}");
                        }, "NumberOfTasks", _passedTests, _failedTests);

                        TrackAssertionResult(() =>
                        {
                            Assert.That(team.OnsiteTeam, Is.Not.Null.Or.Empty.Or.EqualTo(team.PrimaryResource).Or.Null.Or.EqualTo(team.SecondaryResource).Or.Null, $"At least one of OnsiteTeam, PrimaryResource, or SecondaryResource should be present for team {team.ResponsibleTeam}");
                        }, "OnsiteTeam, PrimaryResource, or SecondaryResource", _passedTests, _failedTests);
                    });

                });
            }
            TestContext.WriteLine("Test results:");
            TestContext.WriteLine($"Passed tests: {string.Join(", ", _passedTests)}");
            TestContext.WriteLine($"Failed tests: {string.Join(", ", _failedTests)}");
            Assert.That(_failedTests, Is.Empty, "One or more tests failed.");
        }

        [Test]
        public async Task AddResponsibleTeam_ShouldReturnBool()
        {
            var team = new HypercareResponsibleTeam
            {
                Module = "Account Management",
                ResponsibleTeam = "Account Management",
                ActionType = "Account Management",
                NumberOfTasks = 0,
                OnsiteTeam = "Account Management",
                PrimaryResource = "Account Management",
                SecondaryResource = "Account Management",
                CreatedDate = DateTime.Now,
                CreatedUser = "Account Management",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "Account Management"
            };
            var result = await _client.AddResponsibleTeam(team);
            Assert.That(result, Is.True, "The returned result should be true");
        }

        [Test]
        public async Task UpdateResponsibleTeam_ShouldReturnBool()
        {
            var team = new HypercareResponsibleTeam
            {
                SNo = 13,
                Module = "Account Mgmt",
                ResponsibleTeam = "AM Team",
                ActionType = "Hypercare",
                NumberOfTasks = 16,
                OnsiteTeam = "",
                PrimaryResource = "Mehra",
                SecondaryResource = "RajiReddy / Sahothi",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "Nikhil"

            };
            var result = await _client.UpdateResponsibleTeam(team);
            Assert.That(result, Is.True, "The returned result should be true");
        }

        [Test]
        public async Task DeleteResponsibleTeam_ShouldReturnBool()
        {
            var result = await _client.DeleteResponsibleTeam(13, "Nikhil");
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
