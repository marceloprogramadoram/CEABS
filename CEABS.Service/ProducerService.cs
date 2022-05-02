using AutoMapper;
using CEABS.Domain.Entities;
using CEABS.Domain.Repository;
using CEABS.Service.DTO;
using CEABS.Service.Interface;

namespace CEABS.Service
{
    public class ProducerService : IProducerService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProducerService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ProducerDTO> AddProducerAsync(ProducerDTO producerDTO)
        {
            try
            {
                await _uow.Producers.AddAsync(_mapper.Map<Producer>(producerDTO));
                await _uow.CommitAsync();
                return producerDTO;
            }
            catch (Exception)
            {
                throw new Exception();
            }
            
        }

        public async Task<ProducerDTO> DeleteProducerAsync(int id)
        {
            try
            {
                var producer = await GetProducerByIdAsync(id);
                await _uow.Producers.DeleteAsync(_mapper.Map<Producer>(producer));
                return producer;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public async Task<IEnumerable<ProducerDTO>> GetAllProducerAsync() => ConvertProducersToDTO((await _uow.Producers.GetAllAsync()).ToList());

        private List<ProducerDTO> ConvertProducersToDTO(List<Producer> producers)
        {
            try
            {
                List<ProducerDTO> producersDTO = new List<ProducerDTO>();
                producers.ForEach(model =>
                {
                    producersDTO.Add(_mapper.Map<ProducerDTO>(model));
                });
                return producersDTO;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public async Task<ProducerDTO> GetProducerByIdAsync(int id) => _mapper.Map<ProducerDTO>(await _uow.Producers.GetById(id));

        public async Task<ProducerDTO> GetProducerByNameAsync(string producerName) => _mapper.Map<ProducerDTO>(await _uow.Producers.Get(p => p.Name.ToLower().Equals(producerName.ToLower())));

        public async Task<ProducerDTO> UpdateProducerAsync(int id)
        {
            try
            {
                var producer = await GetProducerByIdAsync(id);
                await _uow.Producers.UpdateAsync(_mapper.Map<Producer>(producer));
                return producer;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
    }
}
