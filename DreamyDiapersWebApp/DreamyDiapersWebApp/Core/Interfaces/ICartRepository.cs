namespace DreamyDiapersWebApp.Core.Interfaces;

public interface ICartRepository
{
    Task<List<CartItem>> GetCartAsync(string userId);
    Task<CartItem?> GetByIdAsync(int itemId, string userId);
    Task<bool> AddAsync(CartItemDto cartItem);
    Task<int> GetQuantityInCartAsync(string userId);
    Task<bool> UpdateAsync(CartItem cartItem);
    Task<bool> DeleteAsync(int cartItemId);
    Task<bool> DeleteAsync(string userId);
}
