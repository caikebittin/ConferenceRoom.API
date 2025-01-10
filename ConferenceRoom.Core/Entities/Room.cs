namespace ConferenceRoom.Core.Entities;
public class Room
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public string Location { get; set; }
    public string Equipment { get; set; }
    public bool IsActive { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}
