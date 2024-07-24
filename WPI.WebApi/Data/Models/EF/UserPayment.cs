using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WPI.WebApi.Data.Models.EF
{
    public class UserPayment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public required string User_Id { get; set; }
        public string PaymentType { get; set; }
        public string Provider { get; set; }
        public string AccountNo { get; set; }
        public DateTime Expiry { get; set; }
        [ForeignKey("User_Id")]
        public required IdentityUser User { get; set; }
    }
}
