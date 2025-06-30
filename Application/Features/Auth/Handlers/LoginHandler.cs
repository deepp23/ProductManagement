using MediatR;
using FluentResults;
using Application.Features.Auth.Commands;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Auth.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, Result<string>>
    {
        private readonly IConfiguration _config;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public LoginHandler(IConfiguration config, IJwtTokenGenerator tokenGenerator)
        {
            _config = config;
            _tokenGenerator = tokenGenerator;
        }

        public Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // Hardcoded user check — replace with DB in real app
            if (request.Username == "admin" && request.Password == "password")
            {
                var token = _tokenGenerator.GenerateToken(request.Username, "Admin");
                return Task.FromResult(Result.Ok(token));
            }

            return Task.FromResult(Result.Fail<string>("Invalid credentials"));
        }
    }
}