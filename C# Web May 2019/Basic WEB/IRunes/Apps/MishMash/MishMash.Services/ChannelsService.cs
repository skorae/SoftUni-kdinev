using MishMash.Data;
using MishMash.Entities;
using MishMash.Entities.Enums;
using MishMash.Services.Contracts;
using MishMash.Services.Dtos.ChannelDtos;
using SIS.MvcFramework.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MishMash.Services
{
    public class ChannelsService : IChannelsService
    {
        private readonly MishMashDbContext context;

        public ChannelsService(MishMashDbContext context)
        {
            this.context = context;
        }

        public ChannelDetailsDto CreateChannel(string name, string description, string tags, string type)
        {
            var channel = this.context
                .Channels
                .FirstOrDefault(x => x.Name == name);

            if (channel != null)
            {
                return null;
            }

            List<Tag> allTags = new List<Tag>();

            foreach (var tag in tags.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries))
            {
                allTags.Add(new Tag
                {
                    Content = tag
                });
            }

            ChannelType channelType = ModelMapper.ProjectTo<ChannelType>(type);

            channel = new Channel()
            {
                Name = name,
                Description = description,
                Tags = allTags,
                Type = channelType
            };

            this.context.Channels.Add(channel);
            this.context.SaveChanges();

            return new ChannelDetailsDto();
        }
    }
}
