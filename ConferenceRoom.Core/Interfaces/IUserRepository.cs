using ConferenceRoom.Core.Entities;

namespace ConferenceRoom.Core.Interfaces;
public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmailAsync(string email);
    Task<bool> EmailExistsAsync(string email);
}
