using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.DataAccess;
using FinalProject.BusinesLogic.Contracts;
using FinalProject.DomainModels;
using System.Net.Mime;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly WebTry2Context _context;

        private readonly ICustomerService _customerService;



        public CustomersController(WebTry2Context context, ICustomerService customerService)
        {
            this._context = context;
            this._customerService = customerService;
        }


        [HttpGet("get customer", Name = "find customer")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerDTO>))]

        public IEnumerable<CustomerDTO> GetCustomer() => _customerService.GetCustomer();


        [HttpGet("Find customew with ID/{id:int}", Name = "find customer with Id")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDTO))]

        public CustomerDTO GetCustomerByID(int id) => _customerService.GetCustomerById(id);

        [HttpPost("Register customer", Name = "Register customer")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult RegisterCustomer([FromBody] CustomerDTO customer)
        {
            try
            {
                if (customer == null || !customer.Id.HasValue)
                {
                    return BadRequest("ERROR");
                }
                var result = _customerService.CreateNewCustomer(customer);
                if (result != true)
                {
                    throw new Exception("Somethings off. Try again");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status501NotImplemented, ex.Message);
            }


        }


        [HttpPut("Edit profile", Name = "Edit profile")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult EditCustomerr([FromBody] CustomerDTO customer)
        {
            try
            {
                if (customer == null || !customer.Id.HasValue)
                {
                    return BadRequest("");
                }

                var C = _customerService.GetCustomerById(customer.Id.Value);

                if (C == null)
                    return NotFound($"Can't find customer with this {customer.Id.Value} Id");

                var result = _customerService.EditCustomer(customer);
                if (result != true)
                {
                    throw new Exception("Somethings off. Try again");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status501NotImplemented, ex.Message);
            }
        }


        [HttpDelete("Delete profile / {Id:int}", Name = "Delete Profile")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                var C = _customerService.GetCustomerById(id);

                if (C == null)
                    return NotFound($"Can't find customer with this {id} Id");

                var result = _customerService.DeleteCustomer(id);

                if (result != true)
                {
                    throw new Exception("Somethings off. Try again");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status501NotImplemented, ex.Message);
            }
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
