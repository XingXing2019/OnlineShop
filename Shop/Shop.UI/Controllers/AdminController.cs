﻿using Microsoft.AspNetCore.Mvc;
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
        private IProductService _productService;

        public AdminController(ApplicationDbContext context)
        {
            _productService = new ProductService(context);
        }

        [HttpGet("products")] 
        public async Task<IActionResult> GetProducts() => Ok(await _productService.GetAll());

        [HttpGet("products/id")]
        public async Task<IActionResult> GetProduct(int id) => Ok(await _productService.Get(id));

        [HttpDelete("products/id")]
        public async Task<IActionResult> DeleteProduct(int id) => Ok(await _productService.Delete(id));

        [HttpPost("products")]
        public async Task<IActionResult> CreateProduct(ProductViewModel vm) => Ok(await _productService.Post(vm));

        [HttpPut("products")]
        public async Task<IActionResult> UpdateProduct(ProductViewModel vm) => Ok(await _productService.Put(vm));
    }
}
