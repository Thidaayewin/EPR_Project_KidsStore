using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPR_Project_ToyStore.Models
{
    [Table("Items_TBL")]
    public class ItemModel
    {
        [Key]
        public int ItemId { get; set; }
        public string? ItemImg { get; set; }
        public string? ItemName { get; set; }
        public double? ItemPrice { get; set; } // Change data type to double?
        public string? ItemDescription { get; set; }
        public int? ItemAgelimit { get; set; }
    }
}
