namespace DreamyDiapersWebApp.Core.DTOs;


public class CartItemNavigationsDto
{
    public Item Item { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
}
public class CartItemDto : CartItemNavigationsDto
{
    public int ItemId { get; set; }

    public int Quantity { get; set; }

    public string ApplicationUserId { get; set; }
}
