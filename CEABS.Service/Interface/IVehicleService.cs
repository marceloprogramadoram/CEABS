using CEABS.Service.DTO;
using CEABS.Service.Filters;

namespace CEABS.Service.Interface
{
    public interface IVehicleService
    {
        Task<List<VehicleDTO>> GetVehiclesByFilter(VehicleFilter vehicleFilter);
        Task<int> GetStatisticVehicleByFilter(VehicleFilter vehicleFilter);
        Task<VehicleDTO> GetVehicleById(int id);
        Task<List<VehicleDTO>> ListAllVehicles();
        Task<VehicleDTO> AddVehicle(VehicleDTO vehicle);
        void RemoveVehicle(int id);
        void UpdateVehicle(int id);


    }
}
