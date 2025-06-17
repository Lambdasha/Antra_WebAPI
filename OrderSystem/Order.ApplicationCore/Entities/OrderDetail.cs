using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Order.ApplicationCore.Entities;

[Table("OrderDetails", Schema = "OrderHistory")]
public class OrderDetail
{
    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(Order))]
    public int OrderId { get; set; }

    public int    ProductId   { get; set; }
    [MaxLength(150)]
    public string ProductName { get; set; } = null!;

    public int     Qty    { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price  { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Discount { get; set; }

    // ---- navigation ----
    [JsonIgnore]
    public Order? Order { get; set; }
}