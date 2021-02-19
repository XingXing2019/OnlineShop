using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Service;
using Shop.Domain.ViewModel;

namespace Shop.UI.Pages.Checkout
{
    public class CustomerInformationModel : PageModel
    {
        [BindProperty]
        public CustomerInfoViewModel CustomerInfo { get; set; }
        
        public IActionResult OnGet()
        {
            var order = new CustomerInfoService(HttpContext.Session).Get();

            if (order == null)
                return Page();
            return RedirectToPage("/Checkout/Payment");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            new CustomerInfoService(HttpContext.Session).Post(CustomerInfo);

            return RedirectToPage("/Checkout/Payment");
        }
    }
}
