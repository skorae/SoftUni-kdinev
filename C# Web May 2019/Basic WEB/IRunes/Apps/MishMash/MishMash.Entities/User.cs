using MishMash.Entities.Enums;
using System.Collections.Generic;

namespace MishMash.Entities
{
    public class User
    {
        public User()
        {
            this.Channels = new List<UserChannel>();
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<UserChannel> Channels { get; set; }

        public UserRole Role { get; set; }
    }
}