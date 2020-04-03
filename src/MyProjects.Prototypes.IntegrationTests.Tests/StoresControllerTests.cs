using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace MyProjects.Prototypes.IntegrationTests.Tests
{
    public class StoresControllerTests
    {
        private readonly TestWebApplicationFactory<TestStartup> _factory;

        public StoresControllerTests()
        {
            _factory = new TestWebApplicationFactory<TestStartup>();
        }

        [Fact]
        public async Task Get()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/stores");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var list = await response.Content.ReadAsAsync<IEnumerable<dynamic>>();
            Assert.Equal(2, list.Count());
        }
    }
}
