using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProucts()
        {
            var products = await _productService.GetProducts();

            if (products == null)
                return NotFound("Products not found");
            else
                return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProduct")]

        public async Task<ActionResult<ProductDTO>> GetProductById(int? id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
                return NotFound("Product not found");
            else
                return Ok(product);
        }

        [HttpPost]

        public async Task<ActionResult> AddProduct([FromBody] ProductDTO request)
        {
            if (request == null)
                return NotFound("Data invalid");

            await _productService.Add(request);

            return new CreatedAtActionResult("GetProduct", "ProductsController", new { id = request.Id }, request);
        }

        [HttpPut]

        public async Task<ActionResult> UpdateProduct([FromBody] ProductDTO request)
        {
            if (request == null)
                return NotFound("Product not found");

            var product = await _productService.Update(request);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveProduct(int? id)
        {

            if (id == null)
                return NotFound("Product not found");

            var product = await _productService.Remove(id);

            return Ok();
        }

    }
}
