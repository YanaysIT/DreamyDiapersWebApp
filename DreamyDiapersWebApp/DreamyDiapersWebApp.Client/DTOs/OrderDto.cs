using DreamyDiapersWebApp.Client.Enums;

namespace DreamyDiapersWebApp.Client.DTOs;

public class OrderSummaryDto
{
    public bool IsPlaced { get; set; }
    public string Message { get; set; } = string.Empty;
    public OrderDto? CreatedOrder { get; set; }
}

public class OrderDto
{
    public int Id { get; set; }
    public string? Email { get; set; } 
    public string? Address { get; set; }
    public decimal Total { get; set; }
    public List<OrderItemDto> OrderItems { get; set; } = [];
}

public class OrderItemDto
{
    public string? Name { get; set; }
    public string? Url { get; set; }
    public decimal Price { get; set; }
    public Currency Currency { get; set; }
    public int Quantity { get; set; }
    public decimal SubTotal { get; set; }
}
