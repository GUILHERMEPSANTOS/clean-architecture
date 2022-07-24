using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> index()
        {
            var products = await _productService.GetProducts();

            return Ok(products);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetProductById(int? id)
        {
            return Ok(await _productService.GetById(id));
        }

        [HttpPost]

        public async Task AddProduct([FromBody] ProductDTO request)
        {
            await _productService.Add(request);
        }

        [HttpPut]

        public async Task UpdateProduct([FromBody] ProductDTO request)
        {
            await _productService.Update(request);
        }

        [HttpDelete("{id}")]
        public async Task RemoveProduct(int? id)
        {
            await _productService.Remove(id);
        }

    }
}