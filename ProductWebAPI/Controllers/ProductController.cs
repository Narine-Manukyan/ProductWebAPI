using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCore;
using ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("Products")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await productRepository.GetAllAsync());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        [HttpGet("Products/{id:int}")]
        public async Task<ActionResult<Product>> GetByID(int id)
        {
            try
            {
                var result = await productRepository.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpPost("Products")]
        [Authorize]
        public async Task<ActionResult<Product>> AddAsync(Product newProduct)
        {
            try
            {
                if (newProduct == null)
                    return BadRequest();
                var createdProduct = await productRepository.AddAsync(newProduct);
                return CreatedAtAction(nameof(GetByID),
                    new { id = createdProduct.Id }, createdProduct);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new product record");
            }
        }

        [HttpPut("Products/{id:int}")]
        [Authorize]
        public async Task<ActionResult<Product>> Update(int id, Product newProduct)
        {
            try
            {
                if (id != newProduct.Id)
                    return BadRequest("Product Id mismatch");
                var productToUpdate = await productRepository.GetByIdAsync(id);
                if (productToUpdate == null)
                {
                    return NotFound($"Employee with Id = {id} was deleted by another user");
                }
                
                var updatedProduct = await productRepository.UpdateAsync(newProduct);
                return updatedProduct;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var exceptionEntry = ex.Entries.Single();
                var dbEntry = await exceptionEntry.GetDatabaseValuesAsync();
                if (dbEntry == null)
                {
                    return NotFound($"Employee with Id = {id} was already deleted");
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict,
                                   $"Employee with Id = {id} was modifed by another user after you got the original values.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating product record");
            }
        }

        [HttpDelete("Products/{id:int}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var productToDelete = await productRepository.GetByIdAsync(id);
                if (productToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} was not found or deleted by another user");
                }
                await productRepository.DeleteAsync(id);
                return Ok();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var exceptionEntry = ex.Entries.Single();
                var dbEntry = await exceptionEntry.GetDatabaseValuesAsync();
                if (dbEntry == null)
                {
                    return NotFound($"Employee with Id = {id} was not found or deleted by another user");
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict,
                                   $"Employee with Id = {id} was modified by another user after you got the original values.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting product record");
            }
        }
    }
}
