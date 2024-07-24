using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WPI.WebApi.Data.Models.EF
{
    public class ShoppingSession
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public required string User_Id { get; set; }
        [ForeignKey("User_Id")]
        public required IdentityUser User { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal Total { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Modified_at { get; set; }
    }
}
