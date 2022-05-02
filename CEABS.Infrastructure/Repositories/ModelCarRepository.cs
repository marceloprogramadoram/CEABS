using CEABS.Domain.Entities;
using CEABS.Domain.Repository;
using CEABS.Infrastructure.Contexts;

namespace CEABS.Infrastructure.Repositories
{
    public class ModelCarRepository : Repository<ModelCar>, IModelCarRepository
    {
        public ModelCarRepository(CeabsContext context) : base(context)
        {
        }
    }
}
