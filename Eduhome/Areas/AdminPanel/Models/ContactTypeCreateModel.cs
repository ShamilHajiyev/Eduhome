using System.ComponentModel.DataAnnotations;

namespace Eduhome.Areas.AdminPanel.Models
{
    public class ContactTypeCreateModel
    {
        [Required, MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(20)]
        public string? ContactWay { get; set; }
    }
}
