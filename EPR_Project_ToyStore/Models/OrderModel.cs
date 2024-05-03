using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPR_Project_ToyStore.Models
{
    [Table("Orders_TBL")]
    public class OrderModel
    {

        [Key]
        public int? OrderId { get; set; }

        public int? CustomerId { get; set; }

        public DateTime? OrderDate { get; set; }

       
    }
}
