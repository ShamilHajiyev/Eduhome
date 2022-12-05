using Eduhome.Areas.AdminPanel.Models;
using Eduhome.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduhome.Areas.AdminPanel.Controllers
{

    public class VideoTourLinkController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public VideoTourLinkController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var videoTourLink = _dbContext.VideoTourLinks.FirstOrDefault();
            return View(videoTourLink);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var videoTourLink = _dbContext.VideoTourLinks.Find(id);

            if (videoTourLink == null)
                return NotFound();

            return View(videoTourLink);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var videoTourLink = await _dbContext.VideoTourLinks.FindAsync(id);

            if (videoTourLink == null)
                return NotFound();

            var model = new VideoTourLinkUpdateModel
            {
                Name = videoTourLink.Name
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, VideoTourLinkUpdateModel model)
        {
            if (id == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View();

            var videoTourLink = await _dbContext.VideoTourLinks.FindAsync(id);

            if (videoTourLink == null)
                return NotFound();

            if (videoTourLink.Id != id)
                return BadRequest();

            var isExistName = await _dbContext.VideoTourLinks.AnyAsync(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != id);

            if (isExistName)
            {
                ModelState.AddModelError("Name", "something went wrong");
                return View();
            }

            videoTourLink.Name = model.Name;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
