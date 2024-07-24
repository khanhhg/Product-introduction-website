using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using WPI.WebApi.Data.Models.EF;

namespace WPI.WebApi.Data.Models.Dto
{
    public class OrderDetailsDto
    {
        public int Id { get; set; }
        public required string User_Id { get; set; }
        public decimal Total { get; set; }
        public DateTime? Created_at { get; set; } = DateTime.Now;
    }
}
