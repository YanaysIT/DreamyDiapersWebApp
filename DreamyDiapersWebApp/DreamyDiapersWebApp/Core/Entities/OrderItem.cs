namespace DreamyDiapersWebApp.Core.Entities;

public class OrderItem
{
    public int Id { get; set; }

    [Required]
    public int OrderId { get; set; }

    [Required]
    public int ItemId { get; set; }

    [Required, Range(1, int.MaxValue)]
    public int Quantity { get; set; }

    public virtual Item Item { get; set; } 
    public virtual Order Order { get; set; } 
}