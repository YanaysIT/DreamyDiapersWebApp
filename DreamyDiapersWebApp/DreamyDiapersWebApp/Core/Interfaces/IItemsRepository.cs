namespace DreamyDiapersWebApp.Core.Interfaces;

public interface IItemsRepository
{
    Task<IEnumerable<TItemDto>> GetItemsAsync<Item, TItemDto>() where Item : class where TItemDto : class;
    Task<TItemDto?> GetItemAsync<Item, TItemDto>(int itemId) where Item : class where TItemDto : class;
    Task<bool> UpdateItemsAsync(IEnumerable<Item> items);
}
