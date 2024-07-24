namespace WPI.WebApi.Data.Models.Dto
{
    public class UserPaymentDto
    {
        public int Id { get; set; }
        public required string User_Id { get; set; }
        public string PaymentType { get; set; }
        public string Provider { get; set; }
        public string AccountNo { get; set; }
        public DateTime Expiry { get; set; }
        public DateTime? Created_at { get; set; } = DateTime.Now;
    }
}
