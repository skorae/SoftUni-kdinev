using MishMash.Entities.Enums;
using System.Collections.Generic;

namespace MishMash.Entities
{
    public class Channel
    {
        public Channel()
        {
            this.Tags = new List<Tag>();
            this.Followers = new List<UserChannel>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ChannelType Type { get; set; }

        public List<Tag> Tags { get; set; }

        public List<UserChannel> Followers { get; set; }
    }
}