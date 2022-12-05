using System.ComponentModel.DataAnnotations;

namespace Eduhome.Areas.AdminPanel.Models
{
    public class InformationItemCreateModel
    {
        [Required, MaxLength(30)]
        public string? Name { get; set; }

        [Required, MaxLength(20)]
        public string? Url { get; set; }
    }
}
