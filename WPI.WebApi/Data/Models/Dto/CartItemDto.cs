namespace WPI.WebApi.Data.Models.Dto
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int Session_Id { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public DateTime? Created_at { get; set; } = DateTime.Now;
    }
}
