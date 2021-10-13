using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIApp.Models.CustomerContact;

namespace WebAPIApp.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerContactController : ControllerBase
    {
        private ICustomerContact_Service _CustomerContact_Service;

        public CustomerContactController(ICustomerContact_Service CustomerContact_Service)
        {
            _CustomerContact_Service = CustomerContact_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddCustomerContact(CustomerContact_Object customercontact)
        {
            var result = await _CustomerContact_Service.AddCustomerContact(customercontact.customer_name, customercontact.customer_number, customercontact.customer_email, customercontact.customer_address);
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
        public async Task<IActionResult> GetAllCustomerContacts()
        {
            var result = await _CustomerContact_Service.GetAllCustomerContacts();
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
        public async Task<IActionResult> UpdateCustomerContact(CustomerContact_Object customercontact)
        {
            var result = await _CustomerContact_Service.UpdateCustomerContact(customercontact.customercontact_id, customercontact.customer_name, customercontact.customer_number, customercontact.customer_email, customercontact.customer_address);
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
        public async Task<IActionResult> DeleteCustomerContact(int customercontact_id)
        {
            var result = await _CustomerContact_Service.DeleteCustomerContact(customercontact_id);
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
        public async Task<IActionResult> GetCustomerContactById(int customercontact_id)
        {
            var result = await _CustomerContact_Service.GetCustomerContactById(customercontact_id);
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
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _CustomerContact_Service.GetAllCustomers();
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
