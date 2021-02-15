using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Database;
using Shop.Domain.Model;
using Shop.Domain.ViewModel;

namespace Shop.Application.Service
{
    public class StockService : IStockService
    {
        private readonly ApplicationDbContext _context;

        public StockService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            return await _context.Products
                .Include(x => x.Stocks)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    Stocks = x.Stocks.Select(y => new StockViewModel
                    {
                        Id = y.Id,
                        ProductId = y.ProductId,
                        Description = y.Description,
                        Qty = y.Qty
                    })
                }).ToListAsync();
        }

        public async Task<StockViewModel> Post(StockViewModel vm)
        {
            var stock = new Stock
            {
                Description = vm.Description,
                Qty = vm.Qty,
                ProductId = vm.ProductId
            };
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            vm.Id = stock.Id;
            return vm;
        }

        public async Task<StockListViewModel> Put(StockListViewModel vm)
        {
            var stocks = new List<Stock>();
            foreach (var stock in vm.Stocks)
            {
                stocks.Add(new Stock
                {
                    Id = stock.Id,
                    Description = stock.Description,
                    Qty = stock.Qty,
                    ProductId = stock.ProductId
                });
            }
            _context.Stocks.UpdateRange(stocks);
            await _context.SaveChangesAsync();
            return vm;
        }

        public async Task<bool> Delete(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null) return false;
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}