using System.ComponentModel.DataAnnotations.Schema;

namespace WPI.WebApi.Data.Models.Dto
{
    public class DiscountDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public bool Active { get; set; }
        public decimal Dicount_Percent { get; set; }
        public DateTime? Created_at { get; set; } = DateTime.Now;
    }
}
