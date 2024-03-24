using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPI.WebApi.Data.Models
{
    public class Product_Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Modified_at { get; set; }
        public DateTime? Delete_at { get; set; }
        public ICollection<Product>? Product { get; set; }

    }
}
