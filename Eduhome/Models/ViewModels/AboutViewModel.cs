using Eduhome.Models.Entities;

namespace Eduhome.Models.ViewModels
{
    public class AboutViewModel
    {
        public ViewCourse? ViewCourse { get; set; }
        public VideoTourLink? VideoTourLink { get; set; }
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
