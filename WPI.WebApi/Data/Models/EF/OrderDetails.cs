using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WPI.WebApi.Data.Models.EF
{
    public class OrderDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal Total { get; set; }
        public int Payment_Id { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Modified_at { get; set; }

    }
}
