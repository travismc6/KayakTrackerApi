namespace KayakTracker.Domain.Models
{
    public class TripAttendee
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public string UserId { get; set; }
    }
}
