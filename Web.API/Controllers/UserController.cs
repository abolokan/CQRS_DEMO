using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("users")]
public class UserController : ApiController
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger, ISender sender) : base(sender)
    {
        _logger = logger;
    }
}
