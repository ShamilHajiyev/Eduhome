using Eduhome.DAL;
using Eduhome.Models;
using Eduhome.Models.Entities;
using Eduhome.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Eduhome.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var sliderItems = _dbContext.SliderItems.ToList();
            var courses = _dbContext.Courses.OrderBy(x => x.StartDate).Take(3).ToList();
            var events = _dbContext.Events.OrderBy(x => x.Date).Take(8).ToList();
            var blogs = _dbContext.Blogs.OrderBy(x => x.PublishDate).Take(3).ToList();

            var homeViewModel = new HomeViewModel
            {
                SliderItems = sliderItems,
                Courses = courses,
                Events = events,
                Blogs = blogs
            };

            return View(homeViewModel);
        }
    }
}