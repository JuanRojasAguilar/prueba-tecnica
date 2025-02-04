using api.Exceptions;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/receipt")]
[Authorize]
public class ReceiptController : ControllerBase
{
    private readonly ReceiptService _receiptService;

    public ReceiptController(ReceiptService receiptService)
    {
        _receiptService = receiptService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var receipts = await _receiptService.GetAllAsync();
        return Ok(receipts);
    }

    [HttpGet]
    [Route("overview")]
    public async Task<IActionResult> GetAllOverview()
    {
        var receipts = await _receiptService.GetAllOverview();

        return Ok(receipts);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {
            var receipt = await _receiptService.GetByIdAsync(id);
            return Ok(receipt);
        }
        catch (ReceiptNotFoundException _)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReceiptDto receiptDto)
    {
        try
        {
            var receipt = await _receiptService.CreateAsync(receiptDto);
            return CreatedAtAction
            (nameof(GetById), new { id = receipt.Id }, receiptDto);
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }
}
