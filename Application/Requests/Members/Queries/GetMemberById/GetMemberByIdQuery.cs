using Application.Abstractions.Messaging;

namespace Application.Requests.Members.Queries.GetMemberById;

public sealed record class GetMemberByIdQuery(Guid MemberId) : IQuery<MemberByIdResponse>
{
}
