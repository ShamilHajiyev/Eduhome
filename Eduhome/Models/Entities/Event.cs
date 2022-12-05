namespace Eduhome.Models.Entities
{
    public class Event : Entity
    {
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Venue { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new Category();
        public List<EventSpeaker> EventSpeakers { get; set; } = new List<EventSpeaker>();
    }
}
