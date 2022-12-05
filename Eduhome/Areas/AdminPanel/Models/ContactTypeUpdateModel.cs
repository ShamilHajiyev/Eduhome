using System.ComponentModel.DataAnnotations;

namespace Eduhome.Areas.AdminPanel.Models
{
    public class ContactTypeUpdateModel
    {
        public string? Name { get; set; }

        public string? ContactWay { get; set; }
    }
}
