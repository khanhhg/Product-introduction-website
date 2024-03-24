using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WPI.WebApi.Data.Models
{
    public class Cart_Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int Session_Id { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Modified_at { get; set; }
    }
}
