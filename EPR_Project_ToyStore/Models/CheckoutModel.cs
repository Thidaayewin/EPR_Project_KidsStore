using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Checkout_TBL")]
public class CheckoutModel
{
    [Key]
    public int? CheckoutId { get; set; }

    public int? CustomerId { get; set; }

    public int? OrderId { get; set; }

    public decimal? TotalAmount { get; set; }
}