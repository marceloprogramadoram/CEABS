using CEABS.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEABS.Service.Interface
{
    public interface IProducerService
    {
        Task<ProducerDTO> AddProducerAsync(ProducerDTO producerDTO);

        Task<ProducerDTO> UpdateProducerAsync(int id);

        Task<ProducerDTO> DeleteProducerAsync(int id);

        Task<IEnumerable<ProducerDTO>> GetAllProducerAsync();
        Task<ProducerDTO> GetProducerByNameAsync(string producerName);
        Task<ProducerDTO> GetProducerByIdAsync(int id);
    }
}
