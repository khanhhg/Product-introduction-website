using System.ComponentModel.DataAnnotations.Schema;

namespace WPI.WebApi.Data.Models.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string SKU { get; set; }
        public int Inventory_Id { get; set; }
        public int Category_Id { get; set; }
        public int Discount_Id { get; set; }
        public decimal Price { get; set; }
        public DateTime? Created_at { get; set; } = DateTime.Now;
    }
}
