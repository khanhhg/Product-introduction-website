using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WPI.WebApi.Data.Models
{
    public class Discount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public bool Active { get; set; }     
        public decimal Dicount_Percent { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Modified_at { get; set; }
        public DateTime? Delete_at { get; set; }
    }
}
