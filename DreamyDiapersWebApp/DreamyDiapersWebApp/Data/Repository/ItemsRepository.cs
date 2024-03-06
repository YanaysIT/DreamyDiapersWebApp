namespace DreamyDiapersWebApp.Data.Repository;

public class ItemsRepository(ApplicationDbContext dbContext, IMapper mapper) : IItemsRepository
{
    readonly ApplicationDbContext _dbContext = dbContext;
    readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<TItemDto>> GetItemsAsync<Item, TItemDto>() where Item : class where TItemDto : class 
    {
        var items = await _dbContext.Set<Item>().ToListAsync();
        return _mapper.Map<IEnumerable<TItemDto>>(items);
    }
    public async Task<TItemDto?> GetItemAsync<Item, TItemDto>(int itemId) where Item : class where TItemDto : class
    {
        var item = await _dbContext.Set<Item>().FindAsync(itemId);
        return _mapper.Map<TItemDto>(item);
    }

    public async Task<bool> UpdateItemsAsync(IEnumerable<Item> items)
    {
        foreach (var item in items)
        {
            _dbContext.Update(item);
        }
        var isUpdated = await _dbContext.SaveChangesAsync() >= 0;
        return isUpdated ;
    }
}
