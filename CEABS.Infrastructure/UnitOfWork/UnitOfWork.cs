using CEABS.Domain.Repository;
using CEABS.Infrastructure.Contexts;
using CEABS.Infrastructure.Repositories;

namespace CEABS.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CeabsContext _context;

        public UnitOfWork(CeabsContext context)
        {
            _context = context;
        }

        public IVehicleRepository Vehicles => new VehicleRepository(_context);
        public IModelCarRepository ModelCars => new ModelCarRepository(_context);
        public IProducerRepository Producers => new ProducerRepository(_context);


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
