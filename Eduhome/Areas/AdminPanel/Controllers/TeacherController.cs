using Eduhome.Areas.AdminPanel.Models;
using Eduhome.DAL;
using Eduhome.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Xml.Linq;

namespace Eduhome.Areas.AdminPanel.Controllers
{
    public class TeacherController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public TeacherController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var teachers = _dbContext.Teachers.ToList();
            return View(teachers);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var teacher = _dbContext.Teachers.Find(id);

            if (teacher == null)
                return NotFound();

            return View(teacher);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherCreateModel teacher)
        {
            if (!ModelState.IsValid)
                return View();

            var teacherEntity = new Teacher
            {
                Name = teacher.Name
            };

            await _dbContext.Teachers.AddAsync(teacherEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var teacher = await _dbContext.Teachers.FindAsync(id);

            if (teacher == null)
                return NotFound();

            var model = new TeacherUpdateModel
            {
                Name = teacher.Name,
                ImageUrl = teacher.ImageUrl,
                Occupation = teacher.Occupation,
                About = teacher.About,
                Degree = teacher.Degree,
                Experience = teacher.Experience,
                Faculty = teacher.Faculty,
                Mail = teacher.Mail,
                Phone = teacher.Phone,
                Skype = teacher.Skype
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, TeacherUpdateModel model)
        {
            if (id == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View();

            var teacher = await _dbContext.Teachers.FindAsync(id);

            if (teacher == null)
                return NotFound();

            if (teacher.Id != id)
                return BadRequest();

            var isExistName = await _dbContext.Teachers.AnyAsync(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != id);

            if (isExistName)
            {
                ModelState.AddModelError("Name", "something went wrong");
                return View();
            }

            teacher.Name = model.Name;
            teacher.ImageUrl = teacher.ImageUrl;
            teacher.Occupation = teacher.Occupation;
            teacher.About = teacher.About;
            teacher.Degree = teacher.Degree;
            teacher.Experience = teacher.Experience;
            teacher.Faculty = teacher.Faculty;
            teacher.Mail = teacher.Mail;
            teacher.Phone = teacher.Phone;
            teacher.Skype = teacher.Skype;

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
