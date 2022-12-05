namespace Eduhome.Models.Entities
{
    public class Blog : Entity
    {
        public string? Name { get; set; }
        public DateTime PublishDate { get; set; }
        public string? PublisherName { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new Category();
    }
}
