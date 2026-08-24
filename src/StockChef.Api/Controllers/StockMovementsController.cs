using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockChef.Application.DTOs.StockMovements;
using StockChef.Application.Features.StockMovements.Commands;
using StockChef.Application.Features.StockMovements.Queries;

namespace StockChef.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class StockMovementsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StockMovementsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StockMovementDto>>> GetAll()
    {
        var result = await _mediator.Send(
            new GetAllStockMovementsQuery());

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<StockMovementDto>> GetById(Guid id)
    {
        var movement = await _mediator.Send(
            new GetStockMovementByIdQuery(id));

        if (movement is null)
            return NotFound();

        return Ok(movement);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        CreateStockMovementDto dto)
    {
        var id = await _mediator.Send(
            new CreateStockMovementCommand(dto));

        return CreatedAtAction(
            nameof(GetById),
            new { id },
            id);
    }
}