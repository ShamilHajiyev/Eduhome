using Eduhome.DAL;
using Eduhome.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduhome.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _dbContext;

        public TeacherController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var teachers = _dbContext.Teachers.ToList();

            var teacherViewModel = new TeacherViewModel
            {
                Teachers = teachers
            };

            return View(teacherViewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var teacher = _dbContext.Teachers.SingleOrDefault(x => x.Id == id);

            if (id == null)
                return NotFound();

            return View(teacher);
        }
    }
}
