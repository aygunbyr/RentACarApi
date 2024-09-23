namespace RentACarApi.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ICarRepository Car { get; }
        IColorRepository Color { get; }
        IFuelRepository Fuel { get; }
        ITransmissionRepository Transmission { get; }

        public Task SaveAsync();
    }
}
