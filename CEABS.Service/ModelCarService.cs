using AutoMapper;
using CEABS.Domain.Entities;
using CEABS.Domain.Repository;
using CEABS.Service.DTO;
using CEABS.Service.Interface;

namespace CEABS.Service
{
    public class ModelCarService : IModelCarService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ModelCarService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ModelCarDTO> AddModel(ModelCarDTO modelCar)
        {
            try
            {
                var model = _mapper.Map<ModelCar>(modelCar);
                await _uow.ModelCars.AddAsync(model);
                await _uow.CommitAsync();
                return modelCar;
            }
            catch (Exception)
            {
                throw new Exception();
            }
            
        }

        public async Task<ModelCarDTO> DeleteModel(int id)
        {
            try
            {
                var model = await GetModelCarById(id);
                await _uow.ModelCars.DeleteAsync(_mapper.Map<ModelCar>(model));
                await _uow.CommitAsync();
                return model;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public async Task<List<ModelCarDTO>> GetAllModelCars()
        {
            try
            {
                return ConvertModelCarToDTO((await _uow.ModelCars.GetAllAsync()).ToList());
            }
            catch (Exception)
            {
                throw new Exception();
            }
           
        }

        public async Task<ModelCarDTO> GetModelCarById(int id)
        {
            try
            {
                return _mapper.Map<ModelCarDTO>(await _uow.ModelCars.GetById(id));
            }
            catch (Exception)
            {
                throw new Exception();
            }
            
        }

        public async Task<ModelCarDTO> GetModelCarByName(string? name)
        {
            try
            {
                return _mapper.Map<ModelCarDTO>(await _uow.ModelCars.Get(model => model.Description.ToLower().Equals(name.ToLower())));
            }
            catch (Exception)
            {

                throw new Exception();
            }
            
        }

        public async Task<ModelCarDTO> UpdateModel(int id)
        {
            try
            {
                var model = await GetModelCarById(id);
                if (model == null)
                    throw new Exception();
                await _uow.ModelCars.UpdateAsync(_mapper.Map<ModelCar>(model));
                await _uow.CommitAsync();
                return model;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        private List<ModelCarDTO> ConvertModelCarToDTO(List<ModelCar> modelCars)
        {
            try
            {
                List<ModelCarDTO> cars = new List<ModelCarDTO>();
                modelCars.ForEach(model =>
                {
                    cars.Add(_mapper.Map<ModelCarDTO>(model));
                });
                return cars;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }


    }
}
