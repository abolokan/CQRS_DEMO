namespace Application.Requests.Members.Queries.GetMemberById;

public sealed record MemberByIdResponse(Guid Id, string Email);
