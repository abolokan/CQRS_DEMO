using Application.Requests.Members.Commands.CreateMember;
using Application.Requests.Members.Queries.GetMemberById;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("members")]
public class MemberController : ApiController
{
    private readonly ILogger<MemberController> _logger;
    private readonly IValidator<CreateMemberCommand> _validator;

    public MemberController(
        ILogger<MemberController> logger,
        ISender sender,
        IValidator<CreateMemberCommand> validator) : base(sender)
    {
        _logger = logger;
        _validator = validator;
    }
    [HttpGet("id")]
    public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetMemberByIdQuery(id);
        var response = await Sender.Send(query, cancellationToken);
        return response.IsSuccess ? Ok() : HandleFailure(response);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(CreateMemberCommand command, CancellationToken cancellationToken)
    {
        //var command = new CreateMemberCommand("test@gmail.com", "", "Bolokan");
        //var result = await _validator.ValidateAsync(command, cancellationToken);
        //if (!result.IsValid)
        //{
        //    return Results.ValidationProblem(result.ToDictionary());
        //}

        var response = await Sender.Send(command, cancellationToken);
        // CreatedAtAction(nameof(GetAsync), new { id = response.Value}, response.Value)
        return response.IsSuccess ? Ok() : HandleFailure(response);
    }
}
