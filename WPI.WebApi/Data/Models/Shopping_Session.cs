using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WPI.WebApi.Data.Models
{
    public class Shopping_Session
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int User_Id { get; set; }
        public Decimal Total { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Modified_at { get; set; }
    }
}
