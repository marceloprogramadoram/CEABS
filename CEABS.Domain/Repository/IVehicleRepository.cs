using CEABS.Domain.Entities;

namespace CEABS.Domain.Repository
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Task<List<Vehicle>> GetVehicles(string? plate, string? model, string? startCreatDate, string? endCreatDate, int page, int perPage);
        Task<List<Vehicle>> SummaryVehicle(string model, string color);

    }
}
