using MishMash.Services.Dtos.ChannelDtos;

namespace MishMash.Services.Contracts
{
    public interface IChannelsService
    {
        ChannelDetailsDto CreateChannel(string name, string description, string tags, string type);
    }
}
