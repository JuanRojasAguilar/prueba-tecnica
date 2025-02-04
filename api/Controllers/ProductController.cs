using api.Dtos.Product;
using api.Exceptions;
using api.Helpers;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;
    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ProductQuery query)
    {
        var products = await _productService.GetAllAsync(query);

        return Ok(products);
    }

    [HttpGet]
    [Route("auditories")]
    public async Task<IActionResult> GetAllAuditories([FromQuery] ProductQuery query)
    {
        var products = await _productService.GetAllAuditoriesAsync(query);

        return Ok(products);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        try
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }
        catch (ProductNotFoundException _)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductDto productDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            await _productService.CreateAsync(productDto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = productDto.Id },
                productDto
            );
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateProductDto productDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            var product = await _productService.UpdateAsync(id, productDto);
            return Ok(product);
        }
        catch (ProductNotFoundException _)
        {
            return NotFound();
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        try
        {
            var product = await _productService.DeleteAsync(id);
            return NoContent();
        }
        catch (ProductNotFoundException)
        {
            return NotFound();
        }
    }
}
