using Exceptionless;
using Exceptionless.Models;
using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WebAPIApp.Models.Product;
using static LOGIC.Services.Interfaces.ILogger_Service;

namespace WebAPIApp.Controllers
{
    [EnableCors("app")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProduct_Service _Product_Service;
        private readonly ILogger_Service logger;

        private static string GetFileName(
                        [CallerFilePath] string file = "",
                        [CallerMemberName] string member = "",
                        [CallerLineNumber] int line = 0)
        {
            return string.Format("{0}_{1}({2})", System.IO.Path.GetFileName(file), member, line);
        }

        public ProductController(IProduct_Service Product_Service, ILogger_Service Logger_Service)
        {
            _Product_Service = Product_Service;
            logger = Logger_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddProduct(Product_Object product)
        {
            var result = await _Product_Service.AddProduct(product.product_name, product.product_description, product.product_price, product.product_type, product.product_brand);
            switch (result.success)
            {
                case true:
                    logger.EventLog(string.Format("Added the product successfully (id: {0}, name: {1}).",
                        result.result_set.id, product.product_name), "Controller", GetFileName());
                    return Ok(result);

                case false:
                    logger.EventLog("Returned 500 response from the server", "Controller", GetFileName());
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
                    logger.EventLog(string.Format("Got all products."), "Controller", GetFileName());
                    return Ok(result);

                case false:
                    logger.EventLog("Returned 500 response from the server", "Controller", GetFileName());
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
                    logger.EventLog(string.Format("Updated product (id: {0}, name: {1}).",
                        result.result_set.id, product.product_name), "Controller", GetFileName());
                    return Ok(result);

                case false:
                    logger.EventLog("Returned 500 response from the server", "Controller", GetFileName());
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
                    logger.EventLog(string.Format("Deleted product (id: {0}).",
                        product_id), "Controller", GetFileName());
                    return Ok(result);

                case false:
                    logger.EventLog("Returned 500 response from the server", "Controller", GetFileName());
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
                    logger.EventLog(string.Format("Got product by id (id: {0}, name: {1}).",
                        product_id, result.result_set.product_name), "Controller", GetFileName());
                    return Ok(result);

                case false:
                    logger.EventLog("Returned 500 response from the server", "Controller", GetFileName());
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
                    logger.EventLog("Returned 500 response from the server", "Controller", GetFileName());
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
                    logger.EventLog("Returned 500 response from the server", "Controller", GetFileName());
                    return Ok(result);
            }
        }
    }
}
