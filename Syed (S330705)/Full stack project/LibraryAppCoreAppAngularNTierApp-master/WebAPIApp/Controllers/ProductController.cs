using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIApp.Models.Product;

namespace WebAPIApp.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProduct_Service _Product_Service;

        public ProductController(IProduct_Service Product_Service)
        {
            _Product_Service = Product_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddProduct(string name, string description)
        {
            var result = await _Product_Service.AddProduct(name, description);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _Product_Service.GetAllProducts();
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProduct(Product_Object product)
        {
            var result = await _Product_Service.UpdateProduct(product.id, product.product_name, product.product_description);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteProduct(int product_id)
        {
            var result = await _Product_Service.DeleteProduct(product_id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetProductById(int product_id)
        {
            var result = await _Product_Service.GetProductById(product_id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }
    }
}
