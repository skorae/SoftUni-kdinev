using MishMash.Services.Dtos.UsersDtos;

namespace MishMash.Services.Contracts
{
    public interface IUsersService
    {
        UserDto RegisterUser(string username, string email, string password);

        UserDto LoginUser(string username, string password);
    }
}
