using System.ComponentModel.DataAnnotations.Schema;
using WPI.WebApi.Data.Models.EF;

namespace WPI.WebApi.Data.Models.Dto
{
    public class PaymentDetailsDto
    {
        public int Id { get; set; }
        public int? Order_Id { get; set; }
        public int Amount { get; set; }
        public string Provider { get; set; }
        public string Status { get; set; }
        public DateTime? Created_at { get; set; } = DateTime.Now;
    }
}
