using UserManagement.Data.Dtos;

namespace UserManagement.Data
{
    public interface IUser
    {
        Task Registration(UserCreateDto createUser);
        IEnumerable<UserViewDto> GetAllUsers();
        Task<UserViewDto> Authenticate(string username, string password);
    }
}
