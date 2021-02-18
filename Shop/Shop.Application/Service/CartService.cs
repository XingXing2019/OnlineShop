using System.Collections.Generic;
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

        public void Post(CartProduct request)
        {
            var stringObject = _session.GetString("cart");
            var cartList = string.IsNullOrEmpty(stringObject)
                ? new List<CartProduct>()
                : JsonConvert.DeserializeObject<List<CartProduct>>(stringObject);

            var cart = cartList.Find(x => x.StockId == request.StockId);

            if (cart == null)
            {
                cartList.Add(new CartProduct
                {
                    StockId = request.StockId,
                    Qty = request.Qty
                });
            }
            else
                cart.Qty += request.Qty;

            stringObject = JsonConvert.SerializeObject(cartList);

            _session.SetString("cart", stringObject);
        }

        public IEnumerable<CartProductViewModel> Get()
        {
            var stringObject = _session.GetString("cart");
            if (string.IsNullOrEmpty(stringObject))
                return new List<CartProductViewModel>();

            var cartList = JsonConvert.DeserializeObject<List<CartProduct>>(stringObject);
            var stockIds = cartList.Select(x => x.StockId);

            var stockList = _context.Stocks
                .Include(x => x.Product)
                .Where(x => stockIds.Contains(x.Id)).ToList();

            var response = new List<CartProductViewModel>();
            foreach (var stock in stockList)
            {
                var cart = cartList.FirstOrDefault(x => x.StockId == stock.Id);
                response.Add(new CartProductViewModel
                {
                    Name = stock.Product.Name,
                    Price = $"${stock.Product.Price}",
                    StockId = stock.Id,
                    Qty = cart?.Qty ?? 0
                });
            }

            return response;
        }
    }
}