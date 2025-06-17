     
using Order.ApplicationCore.Interfaces;
using Order.ApplicationCore.Interfaces.Services;

namespace Order.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orders;

        public OrderService(IOrderRepository orders)
        {
            _orders = orders;
        }
        public Task<IEnumerable<ApplicationCore.Entities.Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationCore.Entities.Order> CreateAsync(ApplicationCore.Entities.Order order)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationCore.Entities.Order>> GetByCustomerAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, ApplicationCore.Entities.Order order)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
