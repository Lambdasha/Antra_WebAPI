namespace Order.ApplicationCore.Interfaces;
using Entities;
public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<Order>> GetByCustomerIdAsync(int customerId, CancellationToken ct = default);
}