using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentResults;
using Application.Features.Users.Commands;
using Infrastructure.Data;
using Domain.Entities;
using Domain.Interfaces;
using BCrypt.Net;

namespace Application.Features.Users.Handlers
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, Result<string>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public RegisterHandler(ApplicationDbContext context, IJwtTokenGenerator tokenGenerator)
        {
            _context = context;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (_context.Users.Any(u => u.Username == request.Username || u.Email == request.Email))
                return Result.Fail("User already exists");

            // Hash password
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = passwordHash
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            var token = _tokenGenerator.GenerateToken(user.Username, user.Role);
            return Result.Ok(token);
        }
    }
}