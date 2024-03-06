namespace DreamyDiapersWebApp.Data.Repository;

public class OrderRepository(ApplicationDbContext dbContext) : IOrderRepository
{
    readonly ApplicationDbContext _dbContext = dbContext;
    //readonly IMapper _mapper = mapper;

    public async Task<bool> AddAsync(Order order)
    {
        var orderEntity = _dbContext.Set<Order>();
        await orderEntity.AddAsync(order);
        var isSaved = await _dbContext.SaveChangesAsync();
        return isSaved >= 0;
    }

    //public async Task<Order?> GetByIdAsync(int id, bool include = false)
    //{
    //    //    if (include)
    //    {
    //        var orderWithNavigations = await _dbContext.Set<Order>()
    //            .Include(o => o.Address)
    //            .Include(o => o.ProductsOrder)
    //            .ThenInclude(o => o.Product)
    //            .FirstOrDefaultAsync(o => o.Id.Equals(id));

    //        return orderWithNavigations;
    //    }
    //    var order = await _dbContext.Set<Order>().FirstOrDefaultAsync(o => o.Id.Equals(id));
    //    return order;
    //}
}
