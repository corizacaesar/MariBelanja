using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Data;
using UserManagement.Data.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _users;

        public UsersController(IUser users)
        {
            _users = users;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Registration(UserCreateDto user)
        {
            try
            {
                await _users.Registration(user);
                return Ok($"Registrasi User {user.UserName} berhasil");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IEnumerable<UserViewDto> GetAllUsers()
        {
            return _users.GetAllUsers();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<UserViewDto>> Authenticate(UserCreateDto createUser)
        {
            try
            {
                var user = await _users.Authenticate(createUser.UserName, createUser.Password);
                if (user == null) return NotFound();
                return Ok(user);
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
