using Eduhome.Areas.AdminPanel.Models;
using Eduhome.DAL;
using Eduhome.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduhome.Areas.AdminPanel.Controllers
{

    public class SliderController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public SliderController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var sliderItems = _dbContext.SliderItems.ToList();
            return View(sliderItems);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var sliderItem = _dbContext.SliderItems.Find(id);

            if (sliderItem == null)
                return NotFound();

            return View(sliderItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateModel sliderItem)
        {
            if (!ModelState.IsValid)
                return View();

            var sliderItemEntity = new SliderItem
            {
                Title = sliderItem.Title,
                Subtitle = sliderItem.Subtitle,
                Description = sliderItem.Description,
                ImageUrl = sliderItem.ImageUrl
            };

            await _dbContext.SliderItems.AddAsync(sliderItemEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var sliderItem = await _dbContext.SliderItems.FindAsync(id);

            if (sliderItem == null)
                return NotFound();

            var model = new SliderUpdateModel
            {
                Title = sliderItem.Title,
                Description = sliderItem.Description,
                Subtitle = sliderItem.Subtitle,
                ImageUrl = sliderItem.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, SliderUpdateModel model)
        {
            if (id == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View();

            var sliderItem = await _dbContext.SliderItems.FindAsync(id);

            if (sliderItem == null)
                return NotFound();

            if (sliderItem.Id != id)
                return BadRequest();

            var isExistTitle = await _dbContext.SliderItems.AnyAsync(x => x.Title.ToLower() == model.Title.ToLower() && x.Id != id);

            if (isExistTitle)
            {
                ModelState.AddModelError("Title", "something went wrong");
                return View();
            }

            sliderItem.Title = model.Title;
            sliderItem.Description = model.Description;
            sliderItem.Subtitle = model.Subtitle;
            sliderItem.ImageUrl = model.ImageUrl;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var sliderItem = await _dbContext.SliderItems.FindAsync(id);

            if (sliderItem == null) return NotFound();

            _dbContext.SliderItems.Remove(sliderItem);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
