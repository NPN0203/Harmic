using Harmic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Harmic.Areas.Admin.Components
{
    [ViewComponent(Name ="MenuView")]
    public class AdminMenuView : ViewComponent    
    {
        private readonly HarmicContext _context;

        public AdminMenuView(HarmicContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbMenus.Where(m => (bool)m.IsActive).OrderBy(m => m.Position).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
