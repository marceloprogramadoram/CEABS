using CEABS.Domain.Entities;
using CEABS.Domain.Repository;
using CEABS.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CEABS.Infrastructure.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {

        public VehicleRepository(CeabsContext context) : base(context)
        {
        }

        public async  Task<List<Vehicle>> GetVehicles(string? plate, string? model, string? startCreatDate, string? endCreatDate, int page, int perPage)
        {
            var vehiclesQuery = base._context.Vehicles.Include(w => w.ModelCar).Include(x => x.Producer).AsQueryable();

            vehiclesQuery = plate != null ? vehiclesQuery.Where(w => w.Plate.ToLower().Contains(plate.ToLower())) : vehiclesQuery;

            vehiclesQuery = model != null ? vehiclesQuery.Where(w => w.ModelCar.Description.ToLower().Contains(model.ToLower())) : vehiclesQuery;

            if (startCreatDate != null && endCreatDate != null)
                vehiclesQuery = vehiclesQuery.Where(w => w.CreateDate >= Convert.ToDateTime(startCreatDate)
                                                                     && w.CreateDate <= Convert.ToDateTime(endCreatDate));

            int skip = page == 1 ? 0 : perPage * (page - 1);

            return await vehiclesQuery.AsNoTracking().Skip(skip).Take(perPage).ToListAsync();
        }

        public async Task<List<Vehicle>> SummaryVehicle(string model, string color)
        {
            var vehicleQuery = base._context.Vehicles.Include(m => m.ModelCar).AsQueryable();

            vehicleQuery = string.IsNullOrEmpty(model) ? vehicleQuery : vehicleQuery.Where(v => v.ModelCar.Description.ToLower().Equals(model.ToLower()));

            vehicleQuery = string.IsNullOrEmpty(color) ? vehicleQuery : vehicleQuery.Where(v => v.Color.ToLower().Equals(color.ToLower()));

            return await vehicleQuery.AsNoTracking().ToListAsync();
        }
    }
}
