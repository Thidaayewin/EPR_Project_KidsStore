using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPR_Project_ToyStore.Models
{
    [Table("Cart_TBL")]
    public class CartModel
    {
        [Key]
        public int? CartId { get; set; }

        public int? OrderId { get; set; }

        public int? ItemId { get; set; }

        public int? Quantity { get; set; }
    }
}
