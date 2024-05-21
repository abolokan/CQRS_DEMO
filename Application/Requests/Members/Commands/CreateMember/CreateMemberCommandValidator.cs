using Application.Abstractions.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Members.Commands.CreateMember;

public sealed class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
{
    public CreateMemberCommandValidator(IApplicationDbContext applicationDbContext)
    {
        RuleFor(m => m.Email).NotEmpty();
        //RuleFor(m => m.Email).MustAsync(async (email, _) =>
        //{
        //    return !await applicationDbContext.Members.AnyAsync(x => x.Email == email);
        //}).WithMessage("The email must be unique");

        RuleFor(m => m.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(m => m.LastName).NotEmpty().MaximumLength(50);
    }
}
