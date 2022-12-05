using Eduhome.Areas.AdminPanel.Models;
using Eduhome.DAL;
using Eduhome.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduhome.Areas.AdminPanel.Controllers
{
    public class TagController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public TagController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var tags = _dbContext.Tags.ToList();
            return View(tags);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var tag = _dbContext.Tags.Find(id);

            if (tag == null)
                return NotFound();

            return View(tag);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TagCreateModel tag)
        {
            if (!ModelState.IsValid)
                return View();

            var tagEntity = new Tag
            {
                Name = tag.Name
            };

            await _dbContext.Tags.AddAsync(tagEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var tag = await _dbContext.Tags.FindAsync(id);

            if (tag == null)
                return NotFound();

            var model = new TagUpdateModel
            {
                Name = tag.Name
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, TagUpdateModel model)
        {
            if (id == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View();

            var tag = await _dbContext.Tags.FindAsync(id);

            if (tag == null)
                return NotFound();

            if (tag.Id != id)
                return BadRequest();

            var isExistName = await _dbContext.Tags.AnyAsync(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != id);

            if (isExistName)
            {
                ModelState.AddModelError("Name", "something went wrong");
                return View();
            }

            tag.Name = model.Name;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null) return NotFound();

        //    var contactType = await _dbContext.ContactTypes.FindAsync(id);

        //    if (contactType == null) return NotFound();

        //    _dbContext.ContactTypes.Remove(contactType);

        //    await _dbContext.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}
    }
}
