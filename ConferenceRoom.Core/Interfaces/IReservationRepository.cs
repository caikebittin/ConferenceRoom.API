using ConferenceRoom.Core.Entities;

namespace ConferenceRoom.Core.Interfaces;
public interface IReservationRepository : IRepository<Reservation>
{
    Task<IEnumerable<Reservation>> GetUserReservationsAsync(Guid userId);
    Task<bool> HasConflictingReservationAsync(Guid roomId, DateTime startTime, DateTime endTime);
}