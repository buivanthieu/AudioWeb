using AudioWeb.Core.Domain.Entities;

namespace AudioWeb.Core.Domain.Interfaces
{
    public interface IChannelRepository
    {
        Task<Channel> GetByIdAsync(int id);
        Task<IEnumerable<Channel>> GetAllAsync();

        Task<Channel> AddAsync(Channel channel);
        Task<Channel> UpdateAsync(Channel channel);
        Task DeleteAsync(int id);

    }
}
