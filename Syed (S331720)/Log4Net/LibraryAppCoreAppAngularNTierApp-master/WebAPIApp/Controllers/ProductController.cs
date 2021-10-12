using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIApp.Models.Product;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;
using log4net;

using System.Collections;

namespace WebAPIApp.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProduct_Service _Product_Service;

 


        public ProductController(IProduct_Service Product_Service, ILogger<ProductController> logger)
        {
            _Product_Service = Product_Service;
            _logger = logger;

        }
        private readonly ILogger<ProductController> _logger;

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddProduct(Product_Object product)
        {
            var result = await _Product_Service.AddProduct(product.product_name, product.product_description, product.product_price, product.product_type, product.product_brand);
            switch (result.success)
            {
                case true:
                    _logger.LogTrace("TRACEEE forecast ready!");
                    _logger.LogCritical("CRITICAL EASDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD");
                    _logger.LogError("ERROR EASDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD");
                    _logger.LogInformation("Info EASDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD");
                    _logger.LogDebug("Debug EASDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD");
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
            var result = await _Product_Service.UpdateProduct(product.id, product.product_name, product.product_description, product.product_price, product.product_type, product.product_brand);
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

        [HttpGet]
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

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllBrands()
        {
            var result = await _Product_Service.GetAllBrands();
            switch (result.Count)
            {
                case 0:
                    return StatusCode(500, result);

                default:
                    return Ok(result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllTypes()
        {
            var result = await _Product_Service.GetAllTypes();
            switch (result.Count)
            {
                case 0:
                    return StatusCode(500, result);

                default:
                    return Ok(result);
            }
        }
    }
}
