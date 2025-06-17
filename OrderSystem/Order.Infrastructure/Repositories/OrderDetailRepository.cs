using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Interfaces;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories;
public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
{
    public OrderDetailRepository(OrderDbContext ctx) : base(ctx) { }
    
    public async Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(
        int orderId,
        CancellationToken ct = default)
    {
        return await _ctx.OrderDetails    
            .Where(d => d.OrderId == orderId)
            .AsNoTracking()
            .ToListAsync(ct);
    }
}