using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Service;
using Shop.Database;
using Shop.Domain.Model;
using Shop.Domain.ViewModel;

namespace Shop.UI.Pages
{
    public class ProductModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductService _productService;

        [BindProperty]
        public CartProduct CartViewModel { get; set; }
        public ProductViewModel Product { get; set; }

        public ProductModel(ApplicationDbContext context)
        {
            _context = context;
            _productService = new ProductService(context);
        }

        public async Task<IActionResult> OnGet(string name)
        {
            Product = await _productService.Get(name);
            if (Product == null)
                return RedirectToPage("Index");
            return Page();
        }

        public IActionResult OnPost()
        {
            new CartService(HttpContext.Session, _context).Post(CartViewModel);
            return RedirectToPage("Cart");
        }
    }
}
