using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order.ApplicationCore.Entities;

public class Order
{
    [Key]
    public int Id { get; set; }

    [Column("Order_Date")]
    public DateTime OrderDate { get; set; }

    public int    CustomerId      { get; set; }
    [MaxLength(100)]
    public string CustomerName    { get; set; } = null!;

    public int    PaymentMethodId { get; set; }
    [MaxLength(50)]
    public string PaymentName     { get; set; } = null!;

    [MaxLength(200)]
    public string ShippingAddress { get; set; } = null!;

    [MaxLength(50)]
    public string ShippingMethod  { get; set; } = null!;

    [Column(TypeName = "decimal(18,2)")]
    public decimal BillAmount     { get; set; }

    [MaxLength(25)]
    public string OrderStatus     { get; set; } = "Pending";

    // ---- navigation ----
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}