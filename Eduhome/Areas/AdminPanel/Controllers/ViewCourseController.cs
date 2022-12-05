using Eduhome.Areas.AdminPanel.Models;
using Eduhome.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduhome.Areas.AdminPanel.Controllers
{

    public class ViewCourseController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public ViewCourseController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var viewCourse = _dbContext.ViewCourses.FirstOrDefault();
            return View(viewCourse);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var viewCourse = _dbContext.ViewCourses.Find(id);

            if (viewCourse == null)
                return NotFound();

            return View(viewCourse);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var viewCourse = await _dbContext.ViewCourses.FindAsync(id);

            if (viewCourse == null)
                return NotFound();

            var model = new ViewCourseUpdateModel
            {
                Title = viewCourse.Title,
                Description = viewCourse.Description,
                ChooseOption = viewCourse.ChooseOption
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, ViewCourseUpdateModel model)
        {
            if (id == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View();

            var viewCourse = await _dbContext.ViewCourses.FindAsync(id);

            if (viewCourse == null)
                return NotFound();

            if (viewCourse.Id != id)
                return BadRequest();

            var isExistTitle = await _dbContext.ViewCourses.AnyAsync(x => x.Title.ToLower() == model.Title.ToLower() && x.Id != id);

            if (isExistTitle)
            {
                ModelState.AddModelError("Title", "something went wrong");
                return View();
            }

            viewCourse.Title = model.Title;
            viewCourse.Description = model.Description;
            viewCourse.ChooseOption = model.ChooseOption;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
