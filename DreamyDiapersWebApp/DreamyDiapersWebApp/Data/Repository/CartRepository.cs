namespace DreamyDiapersWebApp.Data.Repository;

public class CartRepository(ApplicationDbContext dbContext, IMapper mapper) : ICartRepository
{
    readonly ApplicationDbContext _dbContext = dbContext;
    readonly IMapper _mapper = mapper;

    public async Task<List<CartItem>> GetCartAsync(string userId)
    {
        var cart = await _dbContext.Set<CartItem>()
                                        .Include(i => i.Item)
                                        .Where(u => u.ApplicationUserId.Equals(userId))
                                        .ToListAsync();

        return cart;
    }

    public async Task<int> GetQuantityInCartAsync(string userId)
    {
        var quantityInCart = await _dbContext.Set<CartItem>()
                                .Where(c => c.ApplicationUserId.Equals(userId))
                                .SumAsync(c => c.Quantity);

        return quantityInCart;
    }

    public async Task<CartItem?> GetByIdAsync(int itemId, string userId)
    { 
        var cartItem = await _dbContext.Set<CartItem>()
                                         .Include(c => c.Item)
                                         .Where(c => c.ApplicationUserId.Equals(userId))
                                         .FirstOrDefaultAsync(c => c.ItemId.Equals(itemId));
                                    
        return cartItem;
    }

    public async Task<bool> AddAsync(CartItemDto cartItemDto)
    {
        var cartItem = _mapper.Map<CartItem>(cartItemDto);
        await _dbContext.Set<CartItem>().AddAsync(cartItem);
        var isAdded = await _dbContext.SaveChangesAsync() >= 0;
        return isAdded;
    }

    public async Task<bool> UpdateAsync(CartItem cartItem)
    {
        _dbContext.Update(cartItem);
        
        var isSavedChanges = await _dbContext.SaveChangesAsync() >= 0;
        return isSavedChanges;
    }

    public async Task<bool> DeleteAsync(int cartItemId)
    {
        try
        {
            var cartItem = await _dbContext.Set<CartItem>().FindAsync(cartItemId);
            if (cartItem is null)
                return false;
            _dbContext.Remove(cartItem);

            var isRemoved = await _dbContext.SaveChangesAsync() >= 0;
            return isRemoved;
        }
        catch
        {
            throw;
        }
    }

    public async Task<bool> DeleteAsync(string userId)
    {
        try
        {
            var cartItems = await _dbContext.Set<CartItem>()
                             .Where(c => c.ApplicationUserId.Equals(userId))
                             .ToListAsync();

            if (cartItems.Count > 0)
            {
                _dbContext.RemoveRange(cartItems);
                var isRemoved = await _dbContext.SaveChangesAsync() >= 0;
                return isRemoved;
            }
            return true;
        }
        catch
        {
            throw;
        }
    }
}

