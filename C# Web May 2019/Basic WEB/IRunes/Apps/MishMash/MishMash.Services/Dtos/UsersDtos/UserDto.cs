using MishMash.Entities.Enums;

namespace MishMash.Services.Dtos.UsersDtos
{
    public class UserDto
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }
    }
}
