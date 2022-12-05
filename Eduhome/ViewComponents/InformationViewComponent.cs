using Eduhome.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduhome.ViewComponents
{
    public class InformationViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbcontext;

        public InformationViewComponent(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var informationItems = await _dbcontext.InformationItems.ToListAsync();
            return View(informationItems);
        }
    }
}
