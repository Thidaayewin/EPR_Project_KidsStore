using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPR_Project_ToyStore.Models
{
    [Table("Customers_TBL")]
    public class CustomerModel
    {
        [Key]
        public int? CustomerId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? ShippingAddress { get; set; }

        public string? PhoneNumber { get; set; }
    }
}

