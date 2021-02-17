using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Application.Service;
using Shop.Database;
using Shop.Domain.ViewModel;

namespace Shop.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        public IEnumerable<ProductViewModel> Products { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _productService = new ProductService(context);
        }

        public async Task OnGet()
        {
            Products = await _productService.GetAll();
        }
    }
}
