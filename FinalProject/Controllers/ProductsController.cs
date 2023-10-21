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
    public class ProductsController : ControllerBase
    {
        private readonly WebTry2Context _context;
        private readonly IProductService _productService;

        public ProductsController(WebTry2Context context, IProductService productService)
        {
            this._context = context;
            this._productService = productService;
        }


        [HttpGet("Find Product with ID/{id:int}", Name = "find Product with Id")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDTO))]
        public ProductDTO GetProduct(int id) => _productService.GetPrductById(id);



        [HttpPost("Register Product", Name = "Register Product")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult RegisterProduct([FromBody] ProductDTO product, int id)
        {
            try
            {
                if (product == null || !product.Id.HasValue)
                {
                    return BadRequest("ERROR");
                }
                var result = _productService.AddProduct(product);
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


        [HttpPut("Edit product", Name = "Edit product")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult EditProduct([FromBody] ProductDTO product)
        {
            try
            {
                if (product == null || !product.Id.HasValue)
                {
                    return BadRequest("");
                }

                var C = _productService.GetPrductById(product.Id.Value);

                if (C == null)
                    return NotFound($"Can't find customer with this {product.Id.Value} Id");

                var result = _productService.EditProduct(product);
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

        [HttpDelete("Delete product / {Id:int}", Name = "Delete product")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var C = _productService.GetPrductById(id);

                if (C == null)
                    return NotFound($"Can't find customer with this {id} Id");

                var result = _productService.DeleteProduct(id);

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

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
