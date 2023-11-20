using MyGlobalProject.Infrastructure.Token;
using TokenGenerateAPI.Model;

namespace TokenGenerateAPI.Service
{
    public interface ITokenService
    {
        AccessToken CreateAccessToken(TokenOptions tokenOptions, UserTokenDTO user, RoleTokenDTO role);
    }
}
