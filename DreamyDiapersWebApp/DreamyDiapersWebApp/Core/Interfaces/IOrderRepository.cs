namespace DreamyDiapersWebApp.Core.Interfaces;

public interface IOrderRepository
{
    Task<bool> AddAsync(Order order);
    //Task<Order?> GetByIdAsync(int id, bool include = false);
}
