using Application.Abstractions.Messaging;
using Shared;

namespace Application.Requests.Members.Queries.GetMemberById;

internal sealed class GetMemberByIdQueryHandler : IQueryHandler<GetMemberByIdQuery, MemberByIdResponse>
{
    public async Task<Result<MemberByIdResponse>> Handle(GetMemberByIdQuery query, CancellationToken cancellationToken)
    {
        var member = new MemberByIdResponse(query.MemberId, "test@gmail.com");
        return member;
    }
}
