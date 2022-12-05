using Microsoft.AspNetCore.Mvc;

namespace Eduhome.Areas.AdminPanel.Controllers
{
    
    public class DashboardController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
