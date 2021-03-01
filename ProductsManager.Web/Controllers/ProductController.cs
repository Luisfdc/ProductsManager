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
        public async Task<ActionResult<Product>>  Get([FromRoute] int productId)
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
        public async Task<ActionResult<List<Product>>> Get()
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
        public async Task<ActionResult> Post([FromBody] Product value)
        {
            if (!value.ProductDescriptionValidation())
                return BadRequest();

            _productsAplication.AddProducts(value);

            return Ok();
        }

        // PU: api/Product
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Product value)
        {
            if (!value.ProductDescriptionValidation())
                return BadRequest();

            _productsAplication.UpdateProducts(value);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _productsAplication.DeleteProducts(id);

            return Ok();
        }
    }
}
