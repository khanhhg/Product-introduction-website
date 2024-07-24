using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WPI.WebApi.Data.Models.EF
{
    public class OrderItems
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int Order_Id { get; set; }
        [ForeignKey("Order_Id")]
        public OrderDetails? OrderDetails { get; set; }
        public int Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public  Product? Product { get; set; }
        public int Quantity { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Modified_at { get; set; }
    }
}
