namespace DreamyDiapersWebApp.Services;

public class OrderService(ApplicationDbContext dbContext, IOrderRepository orderRepository, 
                          IAddressRepository addressRepository,
                          CartService cartService, ItemsService itemsService)
{
    readonly ApplicationDbContext _dbContext = dbContext;
    readonly IOrderRepository _orderRepository = orderRepository;
    readonly IAddressRepository _addressRepository = addressRepository;
    readonly CartService _cartService = cartService;
    readonly ItemsService _itemsService = itemsService;
    
    public async Task<OrderSummaryDto> PlaceOrderAsync(ApplicationUser user, Address address, ExchangeRateContainer exchange)
    {
        var message = string.Empty;
        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            var cart = await _cartService.GetCartAsync(user.Id);
            var stockCheck = cart.Select(c => c.Item.Stock - c.Quantity);
            if (stockCheck.Any(s => s < 0))
            {
                message = "Oops! It seems there have been updates to our stock.Please review your cart, " +
                                "as availability for some products may have changed.";
                return new OrderSummaryDto() { IsPlaced = false, CreatedOrder = null, Message = message };
            };

            foreach (var cartItem in cart)
                cartItem.Item.Stock -= cartItem.Quantity;

            var itemsToUpdate = cart.Select(c => c.Item);

            var isStockUpdated = await _itemsService.UpdateItemsAsync(itemsToUpdate);

            if (!isStockUpdated)
            {
                message = "Something went wrong while processing the order. Please try again.";
                return new OrderSummaryDto() { IsPlaced = false, CreatedOrder = null, Message = message };
            }
            var existsAddress = await _addressRepository.GetAsync(address);

            if (existsAddress is not null)
            {
                address = existsAddress;
            }

            var order = new Order()
            {
                Address = address,
                ApplicationUserId = user.Id,
                OrderItems = cart.Select(cartItem => new OrderItem
                {
                    Item = cartItem.Item,
                    Quantity = cartItem.Quantity,
                }).ToList()
            };


            var isPlaced= await _orderRepository.AddAsync(order);

            if (!isPlaced)
            {
                message = "Failed to place the order. Please try again.";
                return new OrderSummaryDto() { IsPlaced = false, CreatedOrder = null, Message = message };
            }
            var isCartCleared = await _cartService.ClearCart(user.Id);
            if (!isCartCleared)
            {
                message = "Something went wrong while processing your cart. Please try again.";
                return new OrderSummaryDto() { IsPlaced = false, CreatedOrder = null, Message = message };
            }

            message = "Your Order has been placed!.";
            transaction.Commit();

            var orderDto = MapOrder(order, exchange, user);
            return new OrderSummaryDto() { IsPlaced = true, CreatedOrder = orderDto, Message = message };
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception($"Failed to place the order.\n {ex}");
        }
    }

    public OrderDto MapOrder(Order placedOrder, ExchangeRateContainer exchange, ApplicationUser user)
    {
        var orderSummary = new OrderDto()
            {
                Id = placedOrder.Id,
                Email= user.Email,
                Address = $"{placedOrder.Address.Line1}, {placedOrder.Address.Line2}.\n {placedOrder.Address.City} {placedOrder.Address.PostCode}.\n {placedOrder.Address.Country}",
                OrderItems = placedOrder.OrderItems.Select(oi => new OrderItemDto
                {
                    Name = oi.Item.Name,
                    Url = oi.Item.Url,
                    Price = oi.Item.Price * exchange.Rate,
                    Currency = exchange.ToCurrency,
                    Quantity = oi.Quantity,
                    SubTotal = oi.Quantity * oi.Item.Price * exchange.Rate
                }).ToList(),
                Total = placedOrder.OrderItems.Sum(oi => oi.Item.Price * oi.Quantity * exchange.Rate),
            };
        return orderSummary;
    }
        
}