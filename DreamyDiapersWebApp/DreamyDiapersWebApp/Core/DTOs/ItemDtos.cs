namespace DreamyDiapersWebApp.Core.DTOs;

public class ItemIdDto
{
    public int Id { get; set; }
}

public class ItemSummaryDto : ItemIdDto
{
    public string Name { get; set; }

    public string Url { get; set; }

    public decimal Price { get; set; }

    public decimal OriginalPrice { get; set; }

    public int Stock { get; set; }
}

public class ItemDetailsDto : ItemSummaryDto
{
   public string Description { get; set; } = string.Empty;
}


public class ItemNavigationsDto : ItemDetailsDto
{
    public virtual ICollection<Order>? Orders { get; set; }
}
