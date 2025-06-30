using MediatR;
using FluentResults;

namespace Application.Features.Auth.Commands
{
    public record LoginCommand(string Username, string Password) : IRequest<Result<string>>;
}