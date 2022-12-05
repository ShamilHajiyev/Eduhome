using Eduhome.DAL;
using Eduhome.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduhome.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CourseController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var courses = _dbContext.Courses.ToList();

            var courseViewModel = new CourseViewModel
            {
                Courses = courses
            };

            return View(courseViewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var course = _dbContext.Courses.Include(x => x.Category).SingleOrDefault(x => x.Id == id);

            if (id == null)
                return NotFound();

            return View(course);
        }
    }
}
