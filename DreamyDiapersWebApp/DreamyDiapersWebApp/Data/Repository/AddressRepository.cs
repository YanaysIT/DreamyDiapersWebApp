namespace DreamyDiapersWebApp.Data.Repository;

public class AddressRepository(ApplicationDbContext dbContext) : IAddressRepository
{
    readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Address?> GetAsync(Address address)
    { 
        var addressInDb = await _dbContext.Set<Address>()
                                         .FirstOrDefaultAsync(a => a.Line1.Equals(address.Line1)
                                                                        && a.Line2.Equals(address.Line2)
                                                                        && a.City.Equals(address.City)
                                                                        && a.Country.Equals(address.Country)
                                                                        && a.PostCode.Equals(address.PostCode));

        return addressInDb;
    }
}
