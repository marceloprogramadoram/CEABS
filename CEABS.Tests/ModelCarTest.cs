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
    public class ModelCarTest
    {
        private readonly IntegrationTestFixture<StartupApiTest> _testFixture;
        private const string Category = "Integracao API - ModelCar";

        public ModelCarTest(IntegrationTestFixture<StartupApiTest> testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact(DisplayName = "Cadastrar um Modelo de Carro com sucesso.")]
        [Trait("Category", Category)]
        public async Task ModelCar_Post_ExecutarComSucesso()
        {
            var modelCar = new ModelCar(7, "C3");
            var initialResponse = await _testFixture.Client.PostAsJsonAsync(AppConstants.ModelCarAddPath, modelCar);
            initialResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Cadastrar um Modelo de Carro sem sucesso. Duplicidade de Chave")]
        [Trait("Category", Category)]
        public async Task ModelCar_Post_ExecutarSemSucesso()
        {
            var modelCar = new ModelCar(3, "C3");
            var initialResponse = await _testFixture.Client.PostAsJsonAsync(AppConstants.ModelCarAddPath, modelCar);
            initialResponse.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }
    }
}
