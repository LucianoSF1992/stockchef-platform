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

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        CreateCategoryDto dto)
    {
        var id = await _mediator.Send(
            new CreateCategoryCommand(dto));

        return CreatedAtAction(
            nameof(GetAll),
            new { id },
            id);
    }
}