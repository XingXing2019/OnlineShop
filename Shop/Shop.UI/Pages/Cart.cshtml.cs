using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Service;
using Shop.Database;
using Shop.Domain.ViewModel;

namespace Shop.UI.Pages
{
    public class CartModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CartProductViewModel CartProduct { get; set; }

        public CartModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            CartProduct = new CartService(HttpContext.Session, _context).Get();
            return Page();
        }
    }
}
