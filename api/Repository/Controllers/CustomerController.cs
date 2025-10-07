using api.Dtos.Customer;
using api.Exceptions;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/customer")]
[ApiController]
[Authorize]
public class CustomerController : ControllerBase
{
    private readonly ICustomerProvider _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] CustomerQuery query)
    {
        var customers = await _customerService.GetAllAsync(query);
        return Ok(customers);
    }

    [HttpGet("auditories")]
    public async Task<IActionResult> GetAuditories([FromQuery] CustomerQuery query)
    {
        try
        {
            var customer = await _customerService.GetAuditories(query);
            return Ok(customer);
        }
        catch (CustomerNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        try
        {
            var customer = await _customerService.GetByIdAsync(id);
            return Ok(customer);
        }
        catch (CustomerNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost("")]
    public async Task<IActionResult> Register([FromBody] CreateCustomerDto customerDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            var createdCustomer = await _customerService.CreateAsync(customerDto);

            return CreatedAtAction
            (
                nameof(GetById),
                new { id = customerDto.Id },
                createdCustomer
            );
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateCustomerDto customerDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            var customer = await _customerService.UpdateAsync(id, customerDto);
            return Ok(customer);
        }
        catch (CustomerNotFoundException)
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
            await _customerService.DeleteAsync(id);
            return NoContent();
        }
        catch (CustomerNotFoundException)
        {
            return NotFound();
        }
    }
}
