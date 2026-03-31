using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockChef.Application.Features.Products.Commands;

namespace StockChef.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IMediator mediator, ILogger<ProductsController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        _logger.LogInformation("Creating product: {Name}", command.Name);

        var result = await _mediator.Send(command);

        _logger.LogInformation("Product created with Id: {Id}", result.Id);

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }
}