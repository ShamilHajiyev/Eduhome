using System.ComponentModel.DataAnnotations;

namespace Eduhome.Areas.AdminPanel.Models
{
    public class SocialMediaLinkCreateModel
    {
        [Required, MaxLength(30)]
        public string? Name { get; set; }

        [Required, MaxLength(30)]
        public string? Link { get; set; }
    }
}
