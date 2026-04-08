using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/units")]
public class UnitController : ControllerBase
{
    private readonly IMediator _mediator;

    public UnitController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUnitCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }
}