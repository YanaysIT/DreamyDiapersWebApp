namespace DreamyDiapersWebApp.Core.Entities;

public class Address
{
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string? Line1 { get; set; }

    [Required, MaxLength(50)]
    public string? Line2 { get; set; }

    [Required, MaxLength(25)]
    public string? City { get; set; }

    [Required, MaxLength(25)]
    public string? Country { get; set; }

    [Required, MaxLength(25)]
    public string? PostCode { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = [];
}