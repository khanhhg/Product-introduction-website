namespace WPI.WebApi.Data.Models.Dto
{
    public class ProductInventoryDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Modified_at { get; set; }
        public DateTime? Delete_at { get; set; }
    }
}
