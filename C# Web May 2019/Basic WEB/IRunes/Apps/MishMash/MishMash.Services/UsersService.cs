using MishMash.Data;
using MishMash.Entities;
using MishMash.Entities.Enums;
using MishMash.Services.Contracts;
using MishMash.Services.Dtos.UsersDtos;
using SIS.MvcFramework.Mapping;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MishMash.Services
{
    public class UsersService : IUsersService
    {
        private readonly MishMashDbContext context;

        public UsersService(MishMashDbContext context)
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

            UserDto userDto = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            };

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
                Password = this.HashPassword(password),
                Role = UserRole.User
            };

            if (this.context.Users.Count() == 0)
            {
                user.Role = UserRole.Admin;
            }

            user = this.context.Users.Add(user).Entity;
            this.context.SaveChanges();

            UserDto userDto = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                Role = user.Role
            };

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
