using System.ComponentModel.DataAnnotations.Schema;
using WPI.WebApi.Data.Models.EF;

namespace WPI.WebApi.Data.Models.Dto
{
    public class OrderItemsDto
    {
        public int Id { get; set; }
        public int Order_Id { get; set; }      
        public int Product_Id { get; set; }    
        public int Quantity { get; set; }
        public DateTime? Created_at { get; set; } = DateTime.Now;
    }
}
