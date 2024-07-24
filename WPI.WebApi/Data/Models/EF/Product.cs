using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WPI.WebApi.Data.Models.EF
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
      
        [Column(TypeName = "decimal(18,0)")]
        public decimal Price { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Modified_at { get; set; }
        public DateTime? Delete_at { get; set; }
        [ForeignKey("Category_Id")]
        public ProductCategory? ProductCategory { get; set; }
        [ForeignKey("Inventory_Id")]
        public ProductInventory? ProductInventory { get; set; }
        [ForeignKey("Discount_Id")]
        public Discount? Discount { get; set; }
    }
}
