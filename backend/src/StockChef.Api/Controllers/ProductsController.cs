using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockChef.Application.Features.Products.Commands;
using StockChef.Application.Common;
using StockChef.Application.Features.Products.Queries;
using Microsoft.AspNetCore.Authorization;

namespace StockChef.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] // 🔐 PROTEGE TUDO
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IMediator mediator, ILogger<ProductsController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery(id));

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.Success)
            return BadRequest(result);

        return CreatedAtAction(nameof(GetById), new { id = result.Data!.Id }, result);
    }
}