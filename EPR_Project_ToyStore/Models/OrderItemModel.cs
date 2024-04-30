using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("OrderItem")]
public class OrderItemModel
{
    [Key]
    public int? OrderItemId { get; set; }

    public int? OrderId { get; set; }

    public int? ItemId { get; set; }

    public int? Quantity { get; set; }
}