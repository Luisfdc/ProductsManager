using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsManager;
using ProductsManager.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsManager.Entities;
using ProductsManager.Interfaces;
using FluentValidation;

namespace ProductsManager.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductsAplication _productsAplication;

        public ProductController(IProductsAplication productsAplication)
        {
            _productsAplication = productsAplication;
        }

        // GET: api/Product/productId
        [HttpGet, Route("{productId}")]
        public async Task<IActionResult>  Get([FromRoute] int productId)
        {
            var product = _productsAplication.GetProduct(productId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products =  _productsAplication.GetAllProducts();


            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            if (!product.IsValid())
                return BadRequest(product.ValidationResult.Errors);

            _productsAplication.AddProduct(product);

            return Ok();
        }

        // PU: api/Product
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Product product)
        {
            if (!product.IsValid())
                return BadRequest(product.ValidationResult.Errors);

            _productsAplication.UpdateProduct(product);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _productsAplication.DeleteProduct(id);

            return Ok();
        }
    }
}
