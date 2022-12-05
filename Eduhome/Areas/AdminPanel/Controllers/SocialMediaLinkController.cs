using Eduhome.Areas.AdminPanel.Models;
using Eduhome.DAL;
using Eduhome.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduhome.Areas.AdminPanel.Controllers
{

    public class SocialMediaLinkController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public SocialMediaLinkController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var socialMediaLinks = _dbContext.SocialMediaLinks.ToList();
            return View(socialMediaLinks);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var socialMediaLink = _dbContext.SocialMediaLinks.Find(id);

            if (socialMediaLink == null)
                return NotFound();

            return View(socialMediaLink);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SocialMediaLinkCreateModel socialMediaLink)
        {
            if (!ModelState.IsValid)
                return View();

            var existLink = await _dbContext.SocialMediaLinks.AnyAsync(x => x.Link.ToLower().Equals(socialMediaLink.Link.ToLower()));

            if (existLink)
            {
                ModelState.AddModelError("link", "something went wrong");
                return View();
            }

            var socialMediaLinkEntity = new SocialMediaLink
            {
                Name = socialMediaLink.Name,
                Link = socialMediaLink.Link
            };

            await _dbContext.SocialMediaLinks.AddAsync(socialMediaLinkEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var socialMediaLink = await _dbContext.SocialMediaLinks.FindAsync(id);

            if (socialMediaLink == null)
                return NotFound();

            var model = new SocialMediaLinkUpdateModel
            {
                Name = socialMediaLink.Name,
                Link = socialMediaLink.Link
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, SocialMediaLinkUpdateModel model)
        {
            if (id == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View();

            var socialMediaLink = await _dbContext.SocialMediaLinks.FindAsync(id);

            if (socialMediaLink == null)
                return NotFound();

            if (socialMediaLink.Id != id)
                return BadRequest();

            var isExistName = await _dbContext.SocialMediaLinks.AnyAsync(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != id);

            if (isExistName)
            {
                ModelState.AddModelError("Name", "something went wrong");
                return View();
            }

            socialMediaLink.Name = model.Name;
            socialMediaLink.Link = model.Link;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var socialMediaLink = await _dbContext.SocialMediaLinks.FindAsync(id);

            if (socialMediaLink == null) return NotFound();

            _dbContext.SocialMediaLinks.Remove(socialMediaLink);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
