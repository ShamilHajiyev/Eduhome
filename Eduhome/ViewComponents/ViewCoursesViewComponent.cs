using Eduhome.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduhome.ViewComponents
{
    public class ViewCoursesViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbcontext;

        public ViewCoursesViewComponent(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewCourse = await _dbcontext.ViewCourses.FirstOrDefaultAsync();
            return View(viewCourse);
        }
    }
}
