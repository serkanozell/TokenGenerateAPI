namespace TokenGenerateAPI.Model
{
    public class UserTokenDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string EMail { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
