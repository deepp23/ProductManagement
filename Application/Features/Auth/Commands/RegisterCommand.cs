using MediatR;
using FluentResults;

namespace Application.Features.Users.Commands
{
    public record RegisterCommand(string Username, string Email, string Password)
        : IRequest<Result<string>>;
}