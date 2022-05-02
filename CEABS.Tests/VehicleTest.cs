using Ceabs;
using CEABS.Domain.Entities;
using CEABS.Service.DTO;
using CEABS.Service.Filters;
using CEABS.Tests.Common;
using CEABS.Tests.Config;
using FluentAssertions;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace CEABS.Tests
{
    [Collection(nameof(IntegrationApiTestFixtureCollection))]
    public class VehicleTest
    {
        private readonly IntegrationTestFixture<StartupApiTest> _testFixture;
        private const string Category = "Integracao API - Vehicle";

        public VehicleTest(IntegrationTestFixture<StartupApiTest> testFixture)
        {
            _testFixture = testFixture;
        }

        [Theory]
        [InlineData("JWT-1123", "Verde", 2021, 1, 1)]
        public async Task CreateVehicle_Valid_ResultValidState(string plate, string color, int yearFabrication, int model, int producer)
        {
            Action action = () => new Vehicle(plate, color, yearFabrication, model, producer);
            action.Should().NotThrow();
        }

        [Fact(DisplayName = "Cadastrar um Veículo com sucesso.")]
        [Trait("Category", Category)]
        public async Task Vehicle_Post_ExecutarComSucesso()
        {
            var vehicle = new VehicleDTO()
            {
                Plate = "WST-3422",
                Color = "Prata",
                YearFabrication = 2022,
                ModelCar = "Gol",
                Producer = "VW"
            };
            var initialResponse = await _testFixture.Client.PostAsJsonAsync(AppConstants.VehiclePath, vehicle);
            initialResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Cadastrar um Veículo Sem sucesso.")]
        [Trait("Category", Category)]
        public async Task Vehicle_Post_ExecutarSemSucesso()
        {
            var vehicle = new VehicleDTO()
            {
                Plate = "WST-3422",
                Color = "Prata",
                YearFabrication = 2022,
                ModelCar = "Gols",
                Producer = "VWs"
            };
            var initialResponse = await _testFixture.Client.PostAsJsonAsync(AppConstants.VehiclePath, vehicle);
            initialResponse.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }



        [Fact(DisplayName = "Quantidade de Veículo por modelo e cor com sucesso.")]
        [Trait("Category", Category)]
        public async Task Vehicle_Summary_By_Model_and_Color()
        {
            var vehicle = new VehicleFilter()
            {
                ModelName = "Gol",
                ColorName = "Cinza"
            };
            var initialResponse = await _testFixture.Client.GetAsync($"{AppConstants.VehicleSummaryPath}?"+
                                                                       $"ModelName={vehicle.ModelName}&ColorName={vehicle.ColorName}");
            initialResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Filtro de Veículo por placa com sucesso.")]
        [Trait("Category", Category)]
        public async Task Vehicle_Filter_By_Plate()
        {
            var vehicle = new VehicleFilter()
            {
                Plate = "JHT-9088",
                Page = 1,
                PerPage = 5
            };
            var initialResponse = await _testFixture.Client.GetAsync($"{AppConstants.VehicleFilterPath}?" +
                                                                       $"Page={vehicle.Page}&PerPage={vehicle.PerPage}&Plate={vehicle.Plate}");
            initialResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }


        [Fact(DisplayName = "Filtro de Veículo por modelo com sucesso.")]
        [Trait("Category", Category)]
        public async Task Vehicle_Filter_By_Model()
        {
            var vehicle = new VehicleFilter()
            {
                ModelName = "Gol",
                Page = 1,
                PerPage = 5
            };
            var initialResponse = await _testFixture.Client.GetAsync($"{AppConstants.VehicleFilterPath}?" +
                                                                       $"Page={vehicle.Page}&PerPage={vehicle.PerPage}&ModelName={vehicle.ModelName}");
            initialResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Filtro de Veículo por Data com sucesso.")]
        [Trait("Category", Category)]
        public async Task Vehicle_Filter_By_Create_Date()
        {
            var vehicle = new VehicleFilter()
            {
                StartCreateDate = "02/05/2022",
                EndCreateDate = "03/05/2022",
                Page = 1,
                PerPage = 5
            };
            var initialResponse = await _testFixture.Client.GetAsync($"{AppConstants.VehicleFilterPath}?" +
                                                                       $"Page={vehicle.Page}&PerPage={vehicle.PerPage}&StartCreateDate={vehicle.StartCreateDate}&EndCreateDate={vehicle.EndCreateDate}");
            initialResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }


}
