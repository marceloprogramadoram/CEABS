using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEABS.Domain.Entities
{
    public sealed class ModelCar
    {
        public int Id { get; private set; }
        public string? Description { get; private set; }

        public ModelCar(int id, string? description)
        {
            Id = id;
            Description = description;
        }
    }


}
