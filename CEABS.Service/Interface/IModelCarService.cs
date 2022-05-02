using CEABS.Service.DTO;

namespace CEABS.Service.Interface
{
    public interface IModelCarService
    {
        Task<ModelCarDTO> AddModel(ModelCarDTO modelCar);
        Task<ModelCarDTO> UpdateModel(int id);
        Task<ModelCarDTO> DeleteModel(int id);
        Task<ModelCarDTO> GetModelCarByName(string? name);
        Task<ModelCarDTO> GetModelCarById(int id);
        Task<List<ModelCarDTO>> GetAllModelCars();

    }
}
