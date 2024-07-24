namespace WPI.WebApi.Data.Models.Dto
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public required string User_Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Postal_Code { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public DateTime? Created_at { get; set; } = DateTime.Now;
    }
}
