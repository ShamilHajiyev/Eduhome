using Eduhome.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Eduhome.ViewComponents
{
    public class HomeHeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbcontext;

        public HomeHeaderViewComponent(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
