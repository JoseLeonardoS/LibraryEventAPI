using LibraryEventAPI.Models;
using LibraryEventAPI.Models.Dtos;
using LibraryEventAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace LibraryEventAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _service;

        public UserController(IUserInterface service)
        {
            _service = service;
        }

        [HttpPost("sign-up")]
        public async Task<ActionResult<ResponseModel<UserModel>>> SignUp(SignUpDto data)
        {
            var user = await _service.SignUp(data);
            return Ok(user);
        }

        [HttpPost("sign-in")]
        public async Task<ActionResult<ResponseModel<UserModel>>> SignIn(SignInDto data)
        {
            var user = await _service.SignIn(data);
            return Ok(user);
        }
    }
}
