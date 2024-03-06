namespace DreamyDiapersWebApp.Services;

public class CartService(ICartRepository cartRepository)
{

    private readonly ICartRepository _cartRepository = cartRepository;
    public event Action<int>? OnCartChanged;
   
    public async Task<List<CartItem>> GetCartAsync(string userId)
    {
        try
        {
            var cart = await _cartRepository.GetCartAsync(userId);
            await CartChanged(userId);
            return cart;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to load cart.\n {ex}");
        }
    }

    public async Task<bool> AddToCartAsync(int itemId, int quantityToAdd, string userId, int stock)
    {
        bool isAdded;
        try 
        {
            var cartItem = await _cartRepository.GetByIdAsync(itemId, userId);

            if (cartItem is null)
            {
                var quantity = Math.Min(quantityToAdd, stock);
                var cartItemDto = new CartItemDto()
                {
                    ItemId = itemId,
                    Quantity = quantity,
                    ApplicationUserId = userId
                };

                isAdded = await _cartRepository.AddAsync(cartItemDto);
            }
            else
            {
                isAdded = await UpdateCartAsync(cartItem, cartItem.Quantity + quantityToAdd);
            }

            if (isAdded)
            {
                await CartChanged(userId);
            }
            return isAdded;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to add product to cart.\n {ex}");
        } 
    }
    public async Task<bool> UpdateCartAsync(CartItem cartItem, int quantity)
    {
        bool isUpdated;
        try
        {
            if (cartItem is null || quantity < 0)
                return false;

            cartItem.Quantity = Math.Min(quantity, cartItem.Item.Stock);

            if (quantity.Equals(0)) 
            {
                isUpdated = await _cartRepository.DeleteAsync(cartItem.Id);
            }
            else 
            {
                isUpdated = await _cartRepository.UpdateAsync(cartItem);
            }

            if (isUpdated)
            {
                await CartChanged(cartItem.ApplicationUserId);
            }
            return isUpdated;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to update quantity in cart.\n {ex}");
        }
    }
    public async Task<bool> ClearCart(string userId)
    {
        try
        {
            var cartItems = await _cartRepository.GetCartAsync(userId);

            foreach (var cartItem in cartItems)
            {
                await _cartRepository.DeleteAsync(cartItem.Id);
            }
            await CartChanged(userId);

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to clear the cart.\n {ex}");
        }
    }

    public void RaiseCartChangedEvent(int quantityInCart)
    {
        OnCartChanged?.Invoke(quantityInCart);
    }
    public async Task CartChanged(string userId)
    {
        var quantityInCart = await _cartRepository.GetQuantityInCartAsync(userId);
        RaiseCartChangedEvent(quantityInCart);
    }
}
