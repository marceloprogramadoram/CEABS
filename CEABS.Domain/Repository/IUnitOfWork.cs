namespace CEABS.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IVehicleRepository Vehicles { get; }

        IModelCarRepository ModelCars { get; }

        IProducerRepository Producers { get; }
        Task<int> CommitAsync();
    }
}
