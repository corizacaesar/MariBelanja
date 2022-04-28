using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagement.Data.Dtos;
using UserManagement.Data.Helper;

namespace UserManagement.Data
{
    public class UserRepo : IUser
    {
        private readonly UserManager<IdentityUser> _userManager;
        private AppSettings _appSettings;
        public UserRepo(UserManager<IdentityUser> userManager, IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }
        public async Task<UserViewDto> Authenticate(string username, string password)
        {
            var currUser = await _userManager.FindByNameAsync(username);
            var userResult = await _userManager.CheckPasswordAsync(currUser, password);
            if (!userResult)
                throw new Exception($"Authentikasi gagal!");
            var user = new UserViewDto
            {
                UserName = username,
            };

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return user;
        }

        public IEnumerable<UserViewDto> GetAllUsers()
        {
            var users = new List<UserViewDto>();
            foreach (var user in _userManager.Users)
            {
                users.Add(new UserViewDto { UserName = user.UserName });
            }
            return users;
        }

        public async Task Registration(UserCreateDto createUser)
        {
            try
            {
                var newUser = new IdentityUser
                {
                    UserName = createUser.UserName,
                    Email = createUser.UserName
                };
                var result = await _userManager.CreateAsync(newUser, createUser.Password);
                if (!result.Succeeded)
                {
                    StringBuilder sb = new StringBuilder();
                    var errors = result.Errors;
                    foreach (var error in errors)
                    {
                        sb.Append($"Error: {sb.ToString()}");
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Error {ex.Message}");
            }
        }
    }
}
