using Eduhome.DAL;
using Eduhome.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Eduhome.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ContactController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var contactTypes = _dbContext.ContactTypes.ToList();
            var contactViewModel = new ContactViewModel
            {
                ContactTypes = contactTypes
            };
            return View(contactViewModel);
        }
    }
}
