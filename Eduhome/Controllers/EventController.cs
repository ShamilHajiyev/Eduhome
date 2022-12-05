using Eduhome.DAL;
using Eduhome.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduhome.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _dbContext;

        public EventController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var events = _dbContext.Events.ToList();

            var eventViewModel = new EventViewModel
            {
                Events = events
            };

            return View(eventViewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var @event = _dbContext.Events.Include(x => x.Category).Include(x => x.EventSpeakers).ThenInclude(x => x.Speaker).SingleOrDefault(x => x.Id == id);

            if (id == null)
                return NotFound();

            return View(@event);
        }
    }
}
