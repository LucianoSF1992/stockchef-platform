using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockChef.Application.DTOs.Suppliers;
using StockChef.Application.Features.Suppliers.Commands;
using StockChef.Application.Features.Suppliers.Queries;

namespace StockChef.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuppliersController : ControllerBase
{
    private readonly IMediator _mediator;

    public SuppliersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SupplierDto>>> GetAll()
    {
        var result = await _mediator.Send(
            new GetAllSuppliersQuery());

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SupplierDto>> GetById(Guid id)
    {
        var supplier = await _mediator.Send(
            new GetSupplierByIdQuery(id));

        if (supplier is null)
            return NotFound();

        return Ok(supplier);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        CreateSupplierDto dto)
    {
        var id = await _mediator.Send(
            new CreateSupplierCommand(dto));

        return CreatedAtAction(
            nameof(GetById),
            new { id },
            id);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateSupplierDto dto)
    {
        var updated = await _mediator.Send(
            new UpdateSupplierCommand(id, dto));

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _mediator.Send(
            new DeleteSupplierCommand(id));

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}