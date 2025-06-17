     
using Order.ApplicationCore.Interfaces;
using Order.ApplicationCore.Interfaces.Services;

namespace Order.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orders;

        public OrderService(IOrderRepository orders) => _orders = orders;

        public Task<IEnumerable<ApplicationCore.Entities.Order>> GetAllAsync(CancellationToken ct = default) =>
            _orders.GetAllAsync(ct);

        public Task<IEnumerable<ApplicationCore.Entities.Order>> GetByCustomerAsync(int customerId, CancellationToken ct = default) =>
            _orders.GetByCustomerIdAsync(customerId, ct);

        public Task<ApplicationCore.Entities.Order> CreateAsync(ApplicationCore.Entities.Order order, CancellationToken ct = default) =>
            _orders.AddAsync(order, ct);

        public async Task UpdateAsync(int id, ApplicationCore.Entities.Order order, CancellationToken ct = default)
        {
            order.Id = id;
            await _orders.UpdateAsync(order, ct);
        }

        public Task DeleteAsync(int id, CancellationToken ct = default) =>
            _orders.DeleteAsync(id, ct);
    }
}
