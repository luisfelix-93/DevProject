using DevProjectAPI.Infrastructure.DTO;
using DevProjectAPI.Services;
using Microsoft.AspNetCore.Mvc;
using DevProjectAPI.Infrastructure.Entities;

namespace DevProjectAPI.Controllers.Users
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("GetUser/{pIdUser}")]
        public async Task<IActionResult> GetUserController(string pIdUser)
        {
            ReturnDTO returnDTO = await _userService.GetUserService(pIdUser);
            if (returnDTO.Success)
                return new OkObjectResult(returnDTO);

            return new NotFoundObjectResult(returnDTO);
        }

        [HttpPost]
        [Route("InsertUser")]
        public async Task<IActionResult> InsertUserController([FromBody] User pUser)
        {
            ReturnDTO returnDTO = await _userService.InsertUserService(pUser);
            if (returnDTO.Success)
                return new OkObjectResult(returnDTO);
            return new NotFoundObjectResult(returnDTO);
        }
    }
}
