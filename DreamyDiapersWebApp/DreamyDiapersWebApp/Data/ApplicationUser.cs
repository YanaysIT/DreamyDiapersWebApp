namespace DreamyDiapersWebApp.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public virtual ICollection<CartItem> CartItems { get; set; }
    public virtual ICollection<Order>? Orders { get; set; }
}
