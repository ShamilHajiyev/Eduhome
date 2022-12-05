using Eduhome.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduhome.ViewComponents
{
    public class UsefulLinksViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbcontext;

        public UsefulLinksViewComponent(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var usefulLinks = await _dbcontext.UsefulLinks.ToListAsync();
            return View(usefulLinks);
        }
    }
}
