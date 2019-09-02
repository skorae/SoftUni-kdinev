using MishMash.Entities.Enums;
using System.Collections.Generic;
using MishMash.Services.Dtos.TagsDtos;

namespace MishMash.Services.Dtos.ChannelDtos
{
    public class ChannelDetailsDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ChannelType Type { get; set; }

        public int Followers { get; set; }

        public List<TagDto> Tags { get; set; }
    }
}
