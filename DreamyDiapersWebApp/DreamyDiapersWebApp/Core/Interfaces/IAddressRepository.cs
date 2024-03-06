namespace DreamyDiapersWebApp.Core.Interfaces;

public interface IAddressRepository
{
    Task<Address?> GetAsync(Address address);
}
