namespace Eduhome.Models.Entities
{
    public class EventSpeaker : Entity
    {
        public int EventId { get; set; }
        public Event Event { get; set; } = new Event();
        public int SpeakerId { get; set; }
        public Speaker Speaker { get; set; } = new Speaker();
    }
}
