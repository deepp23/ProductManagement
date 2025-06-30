using System;

namespace Domain.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string username, string role);
    }
}