using Eduhome.Areas.AdminPanel.Models;
using Eduhome.DAL;
using Eduhome.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduhome.Areas.AdminPanel.Controllers
{

    public class UsefulLinkController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public UsefulLinkController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var usefulLinks = _dbContext.UsefulLinks.ToList();
            return View(usefulLinks);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var usefulLink = _dbContext.UsefulLinks.Find(id);

            if (usefulLink == null)
                return NotFound();

            return View(usefulLink);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsefulLinkCreateModel usefulLink)
        {
            if (!ModelState.IsValid)
                return View();

            var existName = await _dbContext.UsefulLinks.AnyAsync(x => x.Name.ToLower().Equals(usefulLink.Name.ToLower()));

            if (existName)
            {
                ModelState.AddModelError("name", "something went wrong");
                return View();
            }

            var existUrl = await _dbContext.UsefulLinks.AnyAsync(x => x.Url.ToLower().Equals(usefulLink.Url.ToLower()));

            if (existUrl)
            {
                ModelState.AddModelError("url", "something went wrong");
                return View();
            }

            var usefulLinkEntity = new UsefulLink
            {
                Name = usefulLink.Name,
                Url = usefulLink.Url
            };

            await _dbContext.UsefulLinks.AddAsync(usefulLinkEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var usefulLink = await _dbContext.UsefulLinks.FindAsync(id);

            if (usefulLink == null)
                return NotFound();

            var model = new UsefulLinkUpdateModel
            {
                Name = usefulLink.Name,
                Url = usefulLink.Url
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, UsefulLinkUpdateModel model)
        {
            if (id == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View();

            var usefulLink = await _dbContext.UsefulLinks.FindAsync(id);

            if (usefulLink == null)
                return NotFound();

            if (usefulLink.Id != id)
                return BadRequest();

            var isExistName = await _dbContext.UsefulLinks.AnyAsync(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != id);

            if (isExistName)
            {
                ModelState.AddModelError("Name", "something went wrong");
                return View();
            }

            usefulLink.Name = model.Name;
            usefulLink.Url = model.Url;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var usefulLink = await _dbContext.UsefulLinks.FindAsync(id);

            if (usefulLink == null) return NotFound();

            _dbContext.UsefulLinks.Remove(usefulLink);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
