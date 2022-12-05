using Eduhome.DAL;
using Eduhome.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduhome.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _dbContext;

        public BlogController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var blogs = _dbContext.Blogs.OrderByDescending(x => x.PublishDate).ToList();

            var blogViewModel = new BlogViewModel
            {
                Blogs = blogs
            };

            return View(blogViewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var blog = _dbContext.Blogs.Include(x => x.Category).SingleOrDefault(x => x.Id == id);

            if (id == null)
                return NotFound();

            return View(blog);
        }
    }
}
