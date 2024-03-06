namespace DreamyDiapersWebApp.Core.DTOs;

public class CartIdDto
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
}
public class CartNavigationsDto : CartIdDto
{
    public virtual ApplicationUser? ApplicationUser { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; } = [];
}

public class CartSummary : CartNavigationsDto
{
    public int ItemsQuantity { get; set; }
    public CartSummary()
    {
        ItemsQuantity = CartItems.Sum(c => c.Quantity);
    }
}
