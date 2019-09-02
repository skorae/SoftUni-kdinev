using System;
using System.Collections.Generic;
using System.Text;

namespace MishMash.Entities
{
    public class UserChannel
    {
        public string FollowerId { get; set; }
        public User Follower { get; set; }

        public string ChannelId { get; set; }
        public Channel Channel { get; set; }
    }
}
