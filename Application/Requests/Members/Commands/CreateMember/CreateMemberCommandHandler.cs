using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Members;
using Shared;

namespace Application.Requests.Members.Commands.CreateMember;

internal sealed class CreateMemberCommandHandler : ICommandHandler<CreateMemberCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateMemberCommandHandler(IUnitOfWork unitOfWork, IApplicationDbContext applicationDbContext)
    {
        _unitOfWork = unitOfWork;
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Result> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        var member = Member.Create(request.Email, request.FirstName, request.LastName);

        _applicationDbContext.Members.Add(member);

        member.Raise(new MemberCreatedDomainEvent(member.Id));

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}