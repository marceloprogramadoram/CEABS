using CEABS.Domain.Entities;
using CEABS.Domain.Repository;
using CEABS.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEABS.Infrastructure.Repositories
{
    public class ProducerRepository : Repository<Producer>, IProducerRepository
    {
        public ProducerRepository(CeabsContext context) : base(context)
        {
        }
    }
}
