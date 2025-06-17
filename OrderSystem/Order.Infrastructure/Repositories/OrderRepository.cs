using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Interfaces;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories;

public class OrderRepository : BaseRepository<ApplicationCore.Entities.Order>, IOrderRepository
{
    public OrderRepository(OrderDbContext ctx) : base(ctx) { }

    public async Task<IEnumerable<ApplicationCore.Entities.Order>> GetByCustomerIdAsync(
        int customerId,
        CancellationToken ct = default)
    {
        return await _ctx.Orders         
            .Include(o => o.OrderDetails)
            .Where(o => o.CustomerId == customerId)
            .AsNoTracking()
            .ToListAsync(ct);
    }
}