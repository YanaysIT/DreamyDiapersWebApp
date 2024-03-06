namespace DreamyDiapersWebApp.Services;

public class ItemsService(IItemsRepository itemsRepository)
{
    private readonly IItemsRepository _itemsRepository = itemsRepository;

    public async Task<IEnumerable<ItemSummaryDto>> GetItemsAsync()
    {
        var items = await _itemsRepository.GetItemsAsync<Item,ItemSummaryDto>();
        return items;
    }

    public async Task<ItemDetailsDto?> GetItemAsync(int itemId)
    {
        var item = await _itemsRepository.GetItemAsync<Item, ItemDetailsDto>(itemId);
        return item;
    }
    public async Task<bool> UpdateItemsAsync(IEnumerable<Item> items)
    {
        var isUpdated = await _itemsRepository.UpdateItemsAsync(items);
        return isUpdated;
    }

}
