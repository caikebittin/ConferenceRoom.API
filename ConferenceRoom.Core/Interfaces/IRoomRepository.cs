using ConferenceRoom.Core.Entities;

namespace ConferenceRoom.Core.Interfaces;
public interface IRoomRepository : IRepository<Room>
{
    Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateTime startTime, DateTime endTime);
}
