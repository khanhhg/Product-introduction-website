using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WPI.WebApi.Data.Models
{
    public class Order_Items
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }     
        public int Order_Id { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Modified_at { get; set; }
    }
}
