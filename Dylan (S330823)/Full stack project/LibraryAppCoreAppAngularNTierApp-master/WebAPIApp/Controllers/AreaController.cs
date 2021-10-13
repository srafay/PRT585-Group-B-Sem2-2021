using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIApp.Models.Area;

namespace WebAPIApp.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private IArea_Service _Area_Service;

        public AreaController(IArea_Service Area_Service)
        {
            _Area_Service = Area_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddArea(Area_Object area)
        {
            var result = await _Area_Service.AddArea(area.postcode, area.cityname, area.statename);
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
        public async Task<IActionResult> GetAllAreas()
        {
            var result = await _Area_Service.GetAllAreas();
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
        public async Task<IActionResult> UpdateArea(Area_Object area)
        {
            var result = await _Area_Service.UpdateArea(area.id, area.postcode, area.cityname, area.statename);
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
        public async Task<IActionResult> DeleteArea(int area_id)
        {
            var result = await _Area_Service.DeleteArea(area_id);
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
        public async Task<IActionResult> GetAreaById(int area_id)
        {
            var result = await _Area_Service.GetAreaById(area_id);
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
