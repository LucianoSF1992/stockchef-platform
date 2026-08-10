using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockChef.Application.DTOs.Categories;
using StockChef.Application.Features.Categories.Commands;
using StockChef.Application.Features.Categories.Queries;

namespace StockChef.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
    {
        var result = await _mediator.Send(
            new GetAllCategoriesQuery());

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CategoryDto>> GetById(Guid id)
    {
        var category = await _mediator.Send(
            new GetCategoryByIdQuery(id));

        if (category is null)
            return NotFound();

        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        CreateCategoryDto dto)
    {
        var id = await _mediator.Send(
            new CreateCategoryCommand(dto));

        return CreatedAtAction(
            nameof(GetById),
            new { id },
            id);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateCategoryDto dto)
    {
        var updated = await _mediator.Send(
            new UpdateCategoryCommand(id, dto));

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _mediator.Send(
            new DeleteCategoryCommand(id));

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}