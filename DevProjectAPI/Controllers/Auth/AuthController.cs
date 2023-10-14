using DevProjectAPI.Infrastructure.DTO;
using DevProjectAPI.Infrastructure.Entities;
using DevProjectAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevProjectAPI.Controllers.Auth
{
    [Route("api/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        [AllowAnonymous]
        [HttpPost("auth")]
        public ActionResult AuthenticateController([FromBody] User pUser)
        {
            ReturnDTO returnDTO = _authService.Authenticate(pUser.UserName, pUser.Password);
            if (returnDTO.Success)
            {
                return new OkObjectResult(returnDTO);
            }

            return new UnauthorizedObjectResult(returnDTO);
        }
    }
}
