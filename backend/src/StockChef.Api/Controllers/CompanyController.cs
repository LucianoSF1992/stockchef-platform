using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StockChef.API.Controllers;

[ApiController]
[Route("api/companies")]
public class CompanyController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCompanyCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }
}