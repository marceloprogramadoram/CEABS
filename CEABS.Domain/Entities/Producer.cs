using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEABS.Domain.Entities
{
    public sealed class Producer
    {
        public int Id { get; private set; }
        public string?  Name { get; private set; }

        public Producer(int id, string? name)
        {
            Id = id;
            Name = name;
        }
    }
}
