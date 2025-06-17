using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Entities;

namespace Order.Infrastructure.Data;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) {}

    public DbSet<ApplicationCore.Entities.Order>       Orders       => Set<ApplicationCore.Entities.Order>();
    public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        // ---- Order ----
        b.Entity<ApplicationCore.Entities.Order>(cfg =>
        {
            cfg.HasKey(o => o.Id);

            cfg.Property(o => o.OrderDate)
                .HasColumnName("Order_Date")
                .HasColumnType("datetime2");

            cfg.Property(o => o.BillAmount)
                .HasColumnType("decimal(18,2)");

            cfg.Property(o => o.OrderStatus)
                .HasColumnName("Order_Status");

            cfg.HasMany(o => o.OrderDetails)
                .WithOne(d => d.Order)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // ---- OrderDetail ----
        b.Entity<OrderDetail>(cfg =>
        {
            cfg.HasKey(d => d.Id);

            cfg.Property(d => d.Price)
                .HasColumnType("decimal(18,2)");

            cfg.Property(d => d.Discount)
                .HasColumnType("decimal(18,2)");
        });
    }
}