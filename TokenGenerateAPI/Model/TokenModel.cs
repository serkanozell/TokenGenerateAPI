using MyGlobalProject.Infrastructure.Token;

namespace TokenGenerateAPI.Model
{
    public class TokenModel
    {
        public TokenOptions TokenOptions { get; set; }
        public UserTokenDTO User { get; set; }
        public RoleTokenDTO Role { get; set; }
    }
}
