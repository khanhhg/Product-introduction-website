namespace WPI.WebApi.Data.Models.UserModel
{
    public class ChangePasswordModel
    {
        public string userID { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set;
        }
    }
}
