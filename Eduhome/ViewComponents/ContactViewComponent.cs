using Eduhome.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduhome.ViewComponents
{
    public class ContactViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbcontext;

        public ContactViewComponent(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var contactTypes = await _dbcontext.ContactTypes.ToListAsync();
            return View(contactTypes);
        }
    }
}
