using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Service;
using Shop.Database;

namespace Shop.UI.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public CartViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(string view = "Default")
        {
            return View(view, new CartService(HttpContext.Session, _context).Get());
        }
    }
}