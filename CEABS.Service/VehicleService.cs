using AutoMapper;
using CEABS.Domain.Entities;
using CEABS.Domain.Repository;
using CEABS.Service.DTO;
using CEABS.Service.Filters;
using CEABS.Service.Interface;

namespace CEABS.Service
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public VehicleService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<VehicleDTO> AddVehicle(VehicleDTO vehicle)
        {

            try
            {
                var modelCar = await _uow.ModelCars.Get(m => m.Description.ToLower().Equals(vehicle.ModelCar.ToLower()));

                var producer = await _uow.Producers.Get(p => p.Name.ToLower().Equals(vehicle.Producer.ToLower()));

                var car = new Vehicle(vehicle.Plate, vehicle.Color, vehicle.YearFabrication, modelCar.Id, producer.Id);

                await _uow.Vehicles.AddAsync(car);

                await _uow.CommitAsync();

                return vehicle;
            }
            catch (Exception e)
            {
                throw new Exception();
            }

        }

        public async Task<int> GetStatisticVehicleByFilter(VehicleFilter vehicleFilter)
        {
            try
            {
                var list = await _uow.Vehicles.SummaryVehicle(vehicleFilter.ModelName, vehicleFilter.ColorName);
                return list.Count;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public async Task<VehicleDTO> GetVehicleById(int id) => _mapper.Map<VehicleDTO>(await _uow.Vehicles.GetById(id));

        public async Task<List<VehicleDTO>> ListAllVehicles() => ConvertVehiclesToDTO((await _uow.Vehicles.GetAllAsync()).ToList());

        private List<VehicleDTO> ConvertVehiclesToDTO(List<Vehicle> vehicles)
        {
            List<VehicleDTO> vehiclesDTO = new List<VehicleDTO>();
            vehicles.ForEach(model =>
            {
                vehiclesDTO.Add(_mapper.Map<VehicleDTO>(model));
            });
            return vehiclesDTO;
        }

        public async Task<List<VehicleDTO>> GetVehiclesByFilter(VehicleFilter vehicleFilter) => ConvertVehiclesToDTO( await _uow.Vehicles.GetVehicles(vehicleFilter.Plate, vehicleFilter.ModelName, vehicleFilter.StartCreateDate, vehicleFilter.EndCreateDate, vehicleFilter.Page, vehicleFilter.PerPage)); 

        public async void RemoveVehicle(int id)
        {
            try
            {
                var vehicle = _mapper.Map<Vehicle>(GetVehicleById(id));
                if (vehicle is null)
                    throw new ArgumentNullException("Veículo não encontrado");
                await _uow.Vehicles.DeleteAsync(vehicle);
                await _uow.CommitAsync();
            }
            catch (Exception)
            {

                throw new Exception();
            }


        }

        public async void UpdateVehicle(int id)
        {
            try
            {
                var vehicle = _mapper.Map<Vehicle>(GetVehicleById(id));
                if (vehicle is null)
                    throw new ArgumentNullException("Veículo não encontrado");
                await _uow.Vehicles.UpdateAsync(vehicle);
                await _uow.CommitAsync();
            }
            catch (Exception)
            {

                throw new Exception();
            }

        }
    }
}
