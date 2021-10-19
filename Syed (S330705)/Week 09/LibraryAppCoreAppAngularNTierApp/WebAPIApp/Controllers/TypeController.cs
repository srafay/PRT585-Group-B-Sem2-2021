using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIApp.Models.Type;

namespace WebAPIApp.Controllers
{
    [EnableCors("app")]
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private IType_Service _Type_Service;

        public TypeController(IType_Service Type_Service)
        {
            _Type_Service = Type_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddType(string name)
        {
            var result = await _Type_Service.AddType(name);
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
        public async Task<IActionResult> GetAllTypes()
        {
            var result = await _Type_Service.GetAllTypes();
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
        public async Task<IActionResult> UpdateType(Type_Object _type)
        {
            var result = await _Type_Service.UpdateType(_type.id, _type.name);
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
        public async Task<IActionResult> DeleteType(int type_id)
        {
            var result = await _Type_Service.DeleteType(type_id);
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
        public async Task<IActionResult> GetTypeById(int type_id)
        {
            var result = await _Type_Service.GetTypeById(type_id);
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
