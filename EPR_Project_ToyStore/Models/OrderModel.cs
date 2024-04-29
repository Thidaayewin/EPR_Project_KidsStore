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
			public int? ItemId { get; set; }
			public decimal? ItemPrice { get; set; }
			public DateTime? OrderDate { get; set; }
			public int? OrderQuantity { get; set; }
			public decimal? Amount { get; set; }
		

			public ItemModel Item { get; set; }

    }
}

