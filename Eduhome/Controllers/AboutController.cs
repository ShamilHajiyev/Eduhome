using Eduhome.DAL;
using Eduhome.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduhome.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AboutController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var viewCourse = _dbContext.ViewCourses.FirstOrDefault();
            var videoTourLink = _dbContext.VideoTourLinks.FirstOrDefault();
            var teachers = _dbContext.Teachers.Take(4).ToList();

            var aboutViewModel = new AboutViewModel
            {
                ViewCourse = viewCourse,
                VideoTourLink = videoTourLink,
                Teachers = teachers
            };

            return View(aboutViewModel);
        }
    }
}
