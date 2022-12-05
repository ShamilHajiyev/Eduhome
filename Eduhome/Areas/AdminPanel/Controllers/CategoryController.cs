using Eduhome.Areas.AdminPanel.Models;
using Eduhome.DAL;
using Eduhome.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduhome.Areas.AdminPanel.Controllers
{
    public class CategoryController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public CategoryController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var categories = _dbContext.Categories.ToList();
            return View(categories);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var category = _dbContext.Categories.Find(id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateModel category)
        {
            if (!ModelState.IsValid)
                return View();

            var categoryEntity = new Category
            {
                Name = category.Name
            };

            await _dbContext.Categories.AddAsync(categoryEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var category = await _dbContext.Categories.FindAsync(id);

            if (category == null)
                return NotFound();

            var model = new CategoryUpdateModel
            {
                Name = category.Name
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, CategoryUpdateModel model)
        {
            if (id == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View();

            var category = await _dbContext.Categories.FindAsync(id);

            if (category == null)
                return NotFound();

            if (category.Id != id)
                return BadRequest();

            var isExistName = await _dbContext.Categories.AnyAsync(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != id);

            if (isExistName)
            {
                ModelState.AddModelError("Name", "something went wrong");
                return View();
            }

            category.Name = model.Name;

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
