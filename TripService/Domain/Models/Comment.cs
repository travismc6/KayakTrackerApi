namespace KayakTracker.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
    }
}
