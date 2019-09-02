using SIS.MvcFramework.Mapping;
using SULS.Data;
using SULS.Models;
using SULS.Services.Contracts;
using SULS.Services.Dtos.UsersDto;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SULS.Services
{
    public class UsersService : IUsersService
    {
        private readonly SULSContext context;

        public UsersService(SULSContext context)
        {
            this.context = context;
        }

        public UserDto LoginUser(string username, string password)
        {
            var user = this.context
                .Users
                .FirstOrDefault(x => (x.Username == username || x.Email == username) 
                    && x.Password == this.HashPassword(password));

            if (user == null)
            {
                return null;
            }

            UserDto userDto = ModelMapper.ProjectTo<UserDto>(user);

            return userDto;
        }

        public UserDto RegisterUser(string username, string email, string password)
        {
            if (this.context.Users.Any(x => x.Username == username))
            {
                return new UserDto { Id = "Username" };
            }

            if (this.context.Users.Any(x => x.Email == email))
            {
                return new UserDto { Id = "Email" };
            }

            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.HashPassword(password)
            };

            user = this.context.Users.Add(user).Entity;
            this.context.SaveChanges();

            UserDto userDto = ModelMapper.ProjectTo<UserDto>(user);

            return userDto;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
