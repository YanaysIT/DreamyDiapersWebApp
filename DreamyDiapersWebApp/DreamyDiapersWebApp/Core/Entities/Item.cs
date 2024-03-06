namespace DreamyDiapersWebApp.Core.Entities;

public class Item 
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Required, MaxLength(600)]
    public string Description { get; set; }

    [Required]
    public string Url { get; set; }

    [Required, Column(TypeName = "decimal(18,4)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal OriginalPrice { get; set; }

    [Required, Range(0, int.MaxValue)]
    public int Stock { get; set; }
}
