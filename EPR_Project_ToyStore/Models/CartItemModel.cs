using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPR_Project_ToyStore.Models
{
    [Table("CartItem")]
    public class CartItemModel
    {
        [Key]
        public int? CartItemId { get; set; }


        public int? CartId { get; set; }


        public int? ItemId { get; set; }


        public int? Quantity { get; set; }
    }
}