using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Service;

namespace Shop.UI.Pages.Checkout
{
    public class PaymentModel : PageModel
    {
        public IActionResult OnGet()
        {
            var info = new CustomerInfoService(HttpContext.Session).Get();
            if (info == null)
                return RedirectToPage("/Checkout/CustomerInformation");
            return Page();
        }

    }
}
