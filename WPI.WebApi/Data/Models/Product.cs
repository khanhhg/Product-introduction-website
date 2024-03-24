using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WPI.WebApi.Data.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string SKU { get; set; }
        public int Inventory_Id { get; set; }
        public int Category_Id { get; set; }
        public int Discount_Id { get; set; }
        public decimal Price { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Modified_at { get; set; }
        public DateTime? Delete_at { get; set; }
        public Product_Category? Product_Category { get; set; }
        public Product_Inventory? Product_Inventory { get; set; }
    }
}
