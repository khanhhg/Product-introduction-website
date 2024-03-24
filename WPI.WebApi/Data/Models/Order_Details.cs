using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WPI.WebApi.Data.Models
{
    public class Order_Details
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string User_Id { get; set; }
        public Decimal Total { get; set; }     
        public int Payment_Id { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Modified_at { get; set; }

    }
}
