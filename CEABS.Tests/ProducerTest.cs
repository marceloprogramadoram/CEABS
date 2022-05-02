using Ceabs;
using CEABS.Domain.Entities;
using CEABS.Tests.Common;
using CEABS.Tests.Config;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace CEABS.Tests
{
    [Collection(nameof(IntegrationApiTestFixtureCollection))]
    public class ProducerTest
    {
        private readonly IntegrationTestFixture<StartupApiTest> _testFixture;
        private const string Category = "Integracao API - Producer";

        public ProducerTest(IntegrationTestFixture<StartupApiTest> testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact(DisplayName = "Cadastrar um Fabricante com sucesso.")]
        [Trait("Category", Category)]
        public async Task Producer_Post_ExecutarComSucesso()
        {
            var producer = new Producer(9, "Citroen");
            var initialResponse = await _testFixture.Client.PostAsJsonAsync(AppConstants.ProducerAddPath, producer);
            initialResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Cadastrar um Fabricante sem sucesso. Duplicidade de Chave")]
        [Trait("Category", Category)]
        public async Task Producer_Post_ExecutarSemSucesso()
        {
            var producer = new Producer(3, "Citroen");
            var initialResponse = await _testFixture.Client.PostAsJsonAsync(AppConstants.ProducerAddPath, producer);
            initialResponse.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }
    }
}
