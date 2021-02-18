using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shop.Database;
using Shop.Domain.Model;
using Shop.Domain.ViewModel;

namespace Shop.Application.Service
{
    public class CartService
    {
        private readonly ISession _session;
        private readonly ApplicationDbContext _context;

        public CartService(ISession session, ApplicationDbContext context)
        {
            _session = session;
            _context = context;
        }

        public void Post(CartProduct cartProduct)
        {
            var stringObject = JsonConvert.SerializeObject(cartProduct);
            
            // TODO: appending the cart

            _session.SetString("cart", stringObject);
        }

        public CartProductViewModel Get()
        {
            // TODO account for multiple items in the cart

            var stringObject = _session.GetString("cart");
            var cartProduct = JsonConvert.DeserializeObject<CartProduct>(stringObject);

            var vm = _context.Stocks
                .Include(x => x.Product)
                .Where(x => x.Id == cartProduct.StockId)
                .Select(x => new CartProductViewModel
                {
                    Name = x.Product.Name,
                    Price = $"${x.Product.Price}",
                    StockId = cartProduct.StockId,
                    Qty = cartProduct.Qty
                }).FirstOrDefault();

            return vm;
        }
    }
}