using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPR_Project_ToyStore.Models
{
    [Table("Items_TBL")]
    public class ItemModel
    {
        [Key]
        public int? ItemId { get; set; }

        public string? ItemName { get; set; }

        public string? ItemDescription { get; set; }

        public decimal? ItemPrice { get; set; }
        
        public int? ItemAgelimit { get; set; }
    }
}
