namespace Order.ApplicationCore.Interfaces.Services;
using Entities;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync(CancellationToken ct = default);
    Task<Order>              CreateAsync(Order order, CancellationToken ct = default);
    Task<IEnumerable<Order>> GetByCustomerAsync(int customerId, CancellationToken ct = default);
    Task                     UpdateAsync(int id, Order order,   CancellationToken ct = default);
    Task                     DeleteAsync(int id,                CancellationToken ct = default);
}