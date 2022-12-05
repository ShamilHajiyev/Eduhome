namespace Eduhome.Models.Entities
{
    public class Category : Entity
    {
        public string? Name { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Event> Events { get; set; } = new List<Event>();
        public List<Blog> Blogs { get; set; } = new List<Blog>();
    }
}
