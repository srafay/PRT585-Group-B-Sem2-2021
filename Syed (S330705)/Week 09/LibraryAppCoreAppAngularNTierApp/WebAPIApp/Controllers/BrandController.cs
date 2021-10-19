using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIApp.Models.Brand;

namespace WebAPIApp.Controllers
{
    [EnableCors("app")]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private IBrand_Service _Brand_Service;

        public BrandController(IBrand_Service Brand_Service)
        {
            _Brand_Service = Brand_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddBrand(string name)
        {
            var result = await _Brand_Service.AddBrand(name);
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
            var result = await _Brand_Service.GetAllBrands();
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
        public async Task<IActionResult> UpdateBrand(Brand_Object brand)
        {
            var result = await _Brand_Service.UpdateBrand(brand.id, brand.name);
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
        public async Task<IActionResult> DeleteBrand(int brand_id)
        {
            var result = await _Brand_Service.DeleteBrand(brand_id);
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
        public async Task<IActionResult> GetBrandById(int brand_id)
        {
            var result = await _Brand_Service.GetBrandById(brand_id);
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
