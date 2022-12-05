using System.ComponentModel;

namespace Eduhome.Models.Entities
{
    public class Course : Entity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? About { get; set; }
        public string? HowToApply { get; set; }
        public string? Certification { get; set; }
        public DateTime StartDate { get; set; }
        public int TotalDuration { get; set; }
        public int ClassDuration { get; set; }
        public string? SkillLevel { get; set; }
        public string? Language { get; set; }
        public int Students { get; set; }
        public string? Assesments { get; set; }
        public decimal Fee { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new Category();
    }
}
