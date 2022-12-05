namespace Eduhome.Models.Entities
{
    public class Speaker : Entity
    {
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? Occupation { get; set; }
        public List<EventSpeaker> EventSpeakers { get; set; } = new List<EventSpeaker>();
    }
}
