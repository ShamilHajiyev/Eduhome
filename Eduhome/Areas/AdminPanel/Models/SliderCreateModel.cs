using System.ComponentModel.DataAnnotations;

namespace Eduhome.Areas.AdminPanel.Models
{
    public class SliderCreateModel
    {
        [Required, MaxLength(30)]
        public string? Title { get; set; }

        [MaxLength(40)]
        public string? Subtitle { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        [Required, MaxLength(20)]
        public string? ImageUrl { get; set; }
    }
}
