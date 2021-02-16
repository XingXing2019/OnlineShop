using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Database;
using Shop.Domain.Model;
using Shop.Domain.ViewModel;

namespace Shop.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ProductViewModel> Get(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price.ToString()
            };
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            return await _context.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price.ToString()
            }).ToListAsync();
        }

        public async Task<ProductViewModel> Post(ProductViewModel vm)
        {
            if (vm == null) return null;
            var isValidPrice = decimal.TryParse(vm.Price, out var price);
            if (!isValidPrice) return null;
            var product = new Product
            {
                Name = vm.Name,
                Description = vm.Description,
                Price = price
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            vm.Id = product.Id;
            return vm;
        }

        public async Task<ProductViewModel> Put(ProductViewModel vm)
        {
            if (vm == null) return null;
            var isValidPrice = decimal.TryParse(vm.Price, out var price);
            if (!isValidPrice) return null;
            var product = await _context.Products.FindAsync(vm.Id);
            product.Name = vm.Name;
            product.Description = vm.Description;
            product.Price = price;
            await _context.SaveChangesAsync();
            return vm;
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}