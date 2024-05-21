using Application.Abstractions.Messaging;
namespace Application.Requests.Members.Commands.CreateMember;

public sealed record CreateMemberCommand(
    string Email,
    string FirstName,
    string LastName) : ICommand;
