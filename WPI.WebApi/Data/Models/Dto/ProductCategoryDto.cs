namespace WPI.WebApi.Data.Models.Dto
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime? Created_at { get; set; } = DateTime.Now;
    }
}
