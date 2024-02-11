using KayakTracker.Domain.Enums;
using KayakTracker.Domain.Models;

namespace KayakTracker.Domain.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public int RiverId { get; set; }
        public string OwnerId { get; set; }
        public StateEnum State { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Stage { get; set; }
        public double? Flow { get; set; }
        public string StartName { get; set; }
        public string StartCoordinates { get; set; }
        public string? EndName { get; set; }
        public string? EndCoordinates { get; set; }
        public double? TimeMinutes { get; set; }
        public double DistanceMiles { get; set; }
        public string? MeasuredAt { get; set; }
        public string? Notes { get; set; }
        public double? AvgSpeed { get; set; }
        public River River { get; set; }
        //public int? Days { get; set; }
        //public List<Photo> Photos { get; set; }
        public List<TripAttendee> TripAttendees { get; set; }
        public List<Highlight> Highlights { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
