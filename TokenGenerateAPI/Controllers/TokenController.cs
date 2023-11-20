using Microsoft.AspNetCore.Mvc;
using TokenGenerateAPI.Model;
using TokenGenerateAPI.Service;

namespace TokenGenerateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult GenerateToken(TokenModel tokenModel)
        {
            var token = _tokenService.CreateAccessToken(tokenModel.TokenOptions, tokenModel.User, tokenModel.Role);
            return Ok(token);
        }
    }
}
