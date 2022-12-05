using Eduhome.Areas.AdminPanel.Models;
using Eduhome.DAL;
using Eduhome.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduhome.Areas.AdminPanel.Controllers
{
    public class BlogController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public BlogController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var blogs = _dbContext.Blogs.Include(x => x.Category).ToList();
            return View(blogs);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var blog = _dbContext.Blogs.Include(x => x.Category).SingleOrDefault(x => x.Id == id);

            if (blog == null)
                return NotFound();

            return View(blog);
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(BlogCreateModel blog)
        //{
        //    if (!ModelState.IsValid)
        //        return View();

        //    var blogEntity = new Blog
        //    {
        //        Name = blog.Name,
        //        PublishDate = blog.PublishDate,
        //        PublisherName = blog.PublisherName,
        //        Content = blog.Content,
        //        ImageUrl = blog.ImageUrl,
        //        Category = blog.Category
        //    };

        //    await _dbContext.ContactTypes.AddAsync(contactTypeEntity);
        //    await _dbContext.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}

        //public async Task<IActionResult> Update(int? id)
        //{
        //    if (id == null)
        //        return NotFound();

        //    var contactType = await _dbContext.ContactTypes.FindAsync(id);

        //    if (contactType == null)
        //        return NotFound();

        //    var model = new ContactTypeUpdateModel
        //    {
        //        Name = contactType.Name,
        //        ContactWay = contactType.ContactWay
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Update(int? id, ContactTypeUpdateModel model)
        //{
        //    if (id == null)
        //        return NotFound();

        //    if (!ModelState.IsValid)
        //        return View();

        //    var contactType = await _dbContext.ContactTypes.FindAsync(id);

        //    if (contactType == null)
        //        return NotFound();

        //    if (contactType.Id != id)
        //        return BadRequest();

        //    var isExistName = await _dbContext.ContactTypes.AnyAsync(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != id);

        //    if (isExistName)
        //    {
        //        ModelState.AddModelError("Name", "something went wrong");
        //        return View();
        //    }

        //    contactType.Name = model.Name;
        //    contactType.ContactWay = model.ContactWay;

        //    await _dbContext.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}

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
