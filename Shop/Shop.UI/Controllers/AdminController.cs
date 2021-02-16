using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Application.Service;
using Shop.Database;
using Shop.Domain.ViewModel;

namespace Shop.UI.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly IStockService _stockService;

        public AdminController(ApplicationDbContext context)
        {
            _productService = new ProductService(context);
            _stockService = new StockService(context);
        }

        [HttpGet("products")] 
        public async Task<IActionResult> GetProducts() => Ok(await _productService.GetAll());

        [HttpGet("products/{id?}")]
        public async Task<IActionResult> GetProduct(int id) => Ok(await _productService.Get(id));
        
        [HttpDelete("products/{id?}")]
        public async Task<IActionResult> DeleteProduct(int id) => Ok(await _productService.Delete(id));

        [HttpPost("products")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductViewModel vm) => Ok(await _productService.Post(vm));

        [HttpPut("products")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductViewModel vm) => Ok(await _productService.Put(vm));



        [HttpGet("stocks")]
        public async Task<IActionResult> GetStock() => Ok(await _stockService.GetAll());

        [HttpDelete("stocks/{id?}")]
        public async Task<IActionResult> DeleteStock(int id) => Ok(await _stockService.Delete(id));

        [HttpPost("stocks")]
        public async Task<IActionResult> CreateStock([FromBody] StockViewModel vm) => Ok(await _stockService.Post(vm));

        [HttpPut("stocks")]
        public async Task<IActionResult> UpdateStock([FromBody] StockListViewModel vm) => Ok(await _stockService.Put(vm));
    }
}
