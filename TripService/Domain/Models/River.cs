using KayakTracker.Domain.Enums;

namespace KayakTracker.Domain.Models
{
    public class River
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public StateEnum State { get; set; }

    }
}
