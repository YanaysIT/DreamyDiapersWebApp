namespace DreamyDiapersWebApp.Core.Entities;

public class CartItem
{
    public int Id { get; set; }

    [Required]
    public int ItemId { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public string ApplicationUserId { get; set; } 

    [JsonIgnore]
    public virtual Item Item { get; set; } = new();

    [JsonIgnore]
    public virtual ApplicationUser ApplicationUser { get; set; }
}
