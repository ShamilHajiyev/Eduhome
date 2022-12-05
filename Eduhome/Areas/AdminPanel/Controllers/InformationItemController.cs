using Eduhome.Areas.AdminPanel.Models;
using Eduhome.DAL;
using Eduhome.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduhome.Areas.AdminPanel.Controllers
{

    public class InformationItemController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public InformationItemController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var informationItems = _dbContext.InformationItems.ToList();
            return View(informationItems);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var informationItem = _dbContext.InformationItems.Find(id);

            if (informationItem == null)
                return NotFound();

            return View(informationItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InformationItemCreateModel informationItem)
        {
            if (!ModelState.IsValid)
                return View();

            var existName = await _dbContext.InformationItems.AnyAsync(x => x.Name.ToLower().Equals(informationItem.Name.ToLower()));

            if (existName)
            {
                ModelState.AddModelError("name", "something went wrong");
                return View();
            }

            var existUrl = await _dbContext.InformationItems.AnyAsync(x => x.Url.ToLower().Equals(informationItem.Url.ToLower()));

            if (existUrl)
            {
                ModelState.AddModelError("url", "something went wrong");
                return View();
            }

            var informationItemEntity = new InformationItem
            {
                Name = informationItem.Name,
                Url = informationItem.Url
            };

            await _dbContext.InformationItems.AddAsync(informationItemEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var informationItem = await _dbContext.InformationItems.FindAsync(id);

            if (informationItem == null)
                return NotFound();

            var model = new InformationItemUpdateModel
            {
                Name = informationItem.Name,
                Url = informationItem.Url
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, InformationItemUpdateModel model)
        {
            if (id == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View();

            var informationItem = await _dbContext.InformationItems.FindAsync(id);

            if (informationItem == null)
                return NotFound();

            if (informationItem.Id != id)
                return BadRequest();

            var isExistName = await _dbContext.InformationItems.AnyAsync(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != id);

            if (isExistName)
            {
                ModelState.AddModelError("Name", "something went wrong");
                return View();
            }

            informationItem.Name = model.Name;
            informationItem.Url = model.Url;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var informationItem = await _dbContext.InformationItems.FindAsync(id);

            if (informationItem == null) return NotFound();

            _dbContext.InformationItems.Remove(informationItem);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
