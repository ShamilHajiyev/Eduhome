using Eduhome.Models.Entities;

namespace Eduhome.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<SliderItem> SliderItems { get; set; } = new List<SliderItem>();
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Event> Events { get; set; } = new List<Event>();
        public List<Blog> Blogs { get; set; } = new List<Blog>();
    }
}
