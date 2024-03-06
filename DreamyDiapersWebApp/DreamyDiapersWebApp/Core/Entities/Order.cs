namespace DreamyDiapersWebApp.Core.Entities;

public class Order
{
    public int Id { get; set; }

    [Required]
    public string ApplicationUserId { get; set; }

    [Required]
    public int AddressId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; }
    public virtual Address Address { get; set; } = new ();
    public virtual ApplicationUser ApplicationUser { get; set; }
}
