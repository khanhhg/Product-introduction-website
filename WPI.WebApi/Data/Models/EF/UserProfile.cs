using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WPI.WebApi.Data.Models.EF
{
    public class UserProfile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string User_Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Postal_Code { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public IdentityUser User { get; set; }
    }
}
