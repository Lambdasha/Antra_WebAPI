namespace Order.ApplicationCore.Interfaces;
using Entities;
public interface IOrderDetailRepository : IRepository<OrderDetail>
{
    Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(int orderId,  CancellationToken ct = default);
}