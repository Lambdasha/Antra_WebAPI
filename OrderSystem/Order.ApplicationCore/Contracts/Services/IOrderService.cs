namespace Order.ApplicationCore.Interfaces.Services;
using Entities;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order>              CreateAsync(Order order);
    Task<IEnumerable<Order>> GetByCustomerAsync(int customerId);
    Task                     UpdateAsync(int id, Order order);
    Task                     DeleteAsync(int id);
}