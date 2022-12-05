using Eduhome.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduhome.ViewComponents
{
    public class SocialMediaViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbcontext;

        public SocialMediaViewComponent(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var socialMediaLinks = await _dbcontext.SocialMediaLinks.ToListAsync();
            return View(socialMediaLinks);
        }
    }
}
