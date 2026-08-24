using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockChef.Application.DTOs.Products;
using StockChef.Application.Features.Products.Commands;
using StockChef.Application.Features.Products.Queries;

namespace StockChef.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
    {
        var result = await _mediator.Send(
            new GetAllProductsQuery());

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductDto>> GetById(Guid id)
    {
        var product = await _mediator.Send(
            new GetProductByIdQuery(id));

        if (product is null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        CreateProductDto dto)
    {
        var id = await _mediator.Send(
            new CreateProductCommand(dto));

        return CreatedAtAction(
            nameof(GetById),
            new { id },
            id);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateProductDto dto)
    {
        await _mediator.Send(
            new UpdateProductCommand(id, dto));

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(
            new DeleteProductCommand(id));

        return NoContent();
    }
}